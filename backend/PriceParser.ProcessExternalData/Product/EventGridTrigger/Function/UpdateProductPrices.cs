﻿using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using PriceParser.Application.Product.Service.Contracts;
using PriceParser.Domain.Product.Entities;
using PriceParser.ProcessExternalData.Product.Const;
using PriceParser.ProcessExternalData.Product.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PriceParser.ProcessExternalData.Product.EventGridTrigger.Function
{
	public class UpdateProductPrices
	{
		private readonly IProductEntityService _service;
		private readonly ILogger<UpdateProductPrices> _logger;

		public UpdateProductPrices(IProductEntityService service, ILogger<UpdateProductPrices> logger)
		{
			_service = service;
			_logger = logger;
		}

		[FunctionName(nameof(UpdateProductPricesHttp))]
		public async Task<IActionResult> UpdateProductPricesHttp(
			[HttpTrigger("post", Route = null)] HttpRequest req,
			ILogger log,
			CancellationToken ct)
		{
			await Execute(ct);
			return new OkResult();
		}

		[FunctionName(nameof(UpdateProductPricesTimer))]
		public async Task UpdateProductPricesTimer(
			[TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
			ILogger log,
			CancellationToken ct)
		{
			await Execute(ct);
		}

		private async Task Execute(CancellationToken ct)
		{
			var products = (await _service.GetAllAsync(ct)).ToList();

			for (var i = 0; i < products.Count; i++)
			{
				var currProduct = products[i];

				var updatedProduct = await _service.ScrapeProduct(currProduct.Url, ct);
				var emailContent = GenerateEmailBody(updatedProduct, i, NotificationType.WELCOME);

				await SendEmailAsync(emailContent, currProduct.UserEmail, i);
			}
		}

		private EmailContent GenerateEmailBody(ProductEntity product, int productNumber, NotificationType type)
		{
			var shortenedTitle = product.Title.Length > 20 ? $"{product.Title[..20]}..." : product.Title;
			var subject = string.Empty;
			var body = string.Empty;

			switch (type)
			{
				case NotificationType.WELCOME:
					subject = $"Welcome to PriceParser for {shortenedTitle}";
					body = ProductEmailMessages.GetWelcomePage(product, productNumber);
					break;
				default:
					// Add other cases for CHANGE_OF_STOCK, LOWEST_PRICE, THRESHOLD_MET
					break;
			}

			return new EmailContent { Subject = subject, Body = body };
		}

		private async Task SendEmailAsync(EmailContent emailContent, string recipient, int emailNumber)
		{
			if (recipient is null)
			{
				_logger.LogWarning($"Email ({emailNumber}) not sent: NO recipients");
				return;
			}

			var client = new SendGridClient("");
			var from = new EmailAddress("akparser@gmail.com", "Price Tracker");
			var msg = new SendGridMessage
			{
				From = from,
				Subject = emailContent.Subject,
				HtmlContent = emailContent.Body
			};

			msg.AddTo(new EmailAddress(recipient));

			var response = await client.SendEmailAsync(msg);

			if (response.StatusCode == HttpStatusCode.Accepted)
			{
				_logger.LogWarning($"Email ({emailNumber}) sent: {response.StatusCode}");
			}
			else
			{
				_logger.LogError($"Failed to sent email ({emailNumber}): {response.StatusCode}");
			}
		}
	}
}
