using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Service.Contracts;
using Lynkco.Warranty.WebAPI.Data.Common.Pagination;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Models;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Controller
{
	[ApiController]
	// [Authorize]
	[Route("product")]
	public class ProductController : BaseController
	{
		private readonly IProductEntityService _service;
		private readonly ILogger<ProductController> _logger;

		public ProductController(
			IProductEntityService service,
			ILogger<ProductController> logger)
		{
			_service = service;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAll([FromQuery] PaginationParametersModel paginationModel, CancellationToken ct)
		{
			if (paginationModel == null)
			{
				paginationModel = new PaginationParametersModel();
			}

			var itemsCount = await _service.GetCount(ct);

			if (itemsCount == 0)
			{
				return NoContent();
			}

			var products = await _service.GetAllAsync(paginationModel, ct);

			return OkPaged(products, paginationModel, itemsCount);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProductEntity>> GetById(string id, CancellationToken ct)
		{
			var product = await _service.GetItemByKeyAsync(id, ct);
			if (product == null)
			{
				return NotFound("Product was not found.");
			}

			return Ok(product);
		}

		[HttpPost("email/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProductEntity>> AddEmailToProduct(string id, EmailRequestModel model, CancellationToken ct)
		{
			var product = await _service.GetItemByKeyAsync(id, ct);
			if (product == null)
			{
				return NotFound("Product was not found.");
			}

			product.UserEmail = model.Email;
			product = await _service.UpdateAsync(product, ct);

			return Ok(product);
		}

		[HttpPost("scrape")]
		public async Task<ActionResult<ProductEntity>> Scrape(ScrapRequestModel model, CancellationToken ct)
		{
			var product = _service.ScrapeProduct(model.Url, ct);

			return Ok(product);
		}
	}
}
