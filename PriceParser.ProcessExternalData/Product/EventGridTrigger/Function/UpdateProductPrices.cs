using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Service.Contracts;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Lynkco.Warranty.WebAPI.ProcessExternalData.Vehicle.Const;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Lynkco.Warranty.WebAPI.ProcessExternalData.Vehicle.EventGridTrigger.Function
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

		[FunctionName("UpdateProductPricesHttp")]
		public async Task<IActionResult> RunHttp(
			[HttpTrigger("post", Route = null)] HttpRequest req,
			ILogger log,
			CancellationToken ct)
		{
			await Execute(ct);
			return new OkResult();
		}

		[FunctionName("UpdateProductPricesTimer")]
		public async Task Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
			ILogger log,
			CancellationToken ct)
		{
			// await Execute(ct);
		}

		/*[FunctionName("UpdateVehicleData")]
		public async Task Run([EventGridTrigger] EventGridEvent eventGridEvent,
			ILogger log,
			CancellationToken ct)
		{
			log.LogInformation($"EventType: {eventGridEvent.EventType}");
			log.LogInformation($"Event Data: {eventGridEvent.Data}");

			var data = JsonConvert.DeserializeObject<string>(eventGridEvent.Data.ToString());
			await Execute(eventGridEvent.EventType, data, ct);
		}*/

		private async Task Execute(CancellationToken ct)
		{
			var products = (await _service.GetAllAsync(ct)).ToList();

			for (var i = 0; i < products.Count; i++)
			{
				var currProduct = products[i];

				var updatedProduct = await _service.ScrapeProduct(currProduct.Url, ct);
				var emailContent = GenerateEmailBody(updatedProduct, i, NotificationType.WELCOME);

				await SendEmailAsync(emailContent, new() { currProduct.UserEmail }, i);
			}
		}

		private EmailContent GenerateEmailBody(ProductEntity product, int productNumber, NotificationType type)
		{
			string shortenedTitle = product.Title.Length > 20 ? $"{product.Title.Substring(0, 20)}..." : product.Title;
			string subject = string.Empty;
			string body = string.Empty;

			switch (type)
			{
				case NotificationType.WELCOME:
					subject = $"Welcome to PriceParser for {shortenedTitle}";
					body = ProductEmailMessages.GetWelcomePage(product, productNumber);
					break;

					// Add other cases for CHANGE_OF_STOCK, LOWEST_PRICE, THRESHOLD_MET
			}

			return new EmailContent { Subject = subject, Body = body };
		}

		private async Task SendEmailAsync(EmailContent emailContent, List<string> recipients, int emailNumber)
		{
			if (recipients.Count == 0)
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

			foreach (var recipient in recipients)
			{
				msg.AddTo(new EmailAddress(recipient));
			}

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
