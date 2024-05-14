using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Service.Contracts;
using Lynkco.Warranty.WebAPI.Data.Common.Pagination;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Controller
{
	[ApiController]
	// [Authorize]
	[Route("product")]
	public class VehicleWarrantyController : BaseController
	{
		private readonly IProductEntityService _service;
		private readonly ILogger<VehicleWarrantyController> _logger;

		public VehicleWarrantyController(
			IProductEntityService service,
			ILogger<VehicleWarrantyController> logger)
		{
			_service = service;
			_logger = logger;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult<IEnumerable<ProductEntity>>> GetAll(
			[FromQuery] PaginationParametersModel paginationModel,
			CancellationToken cancellationToken)
		{
			if (paginationModel == null)
			{
				paginationModel = new PaginationParametersModel();
			}

			var itemsCount = await _service.GetCount(cancellationToken);

			if (itemsCount == 0)
			{
				return NoContent();
			}

			var products = await _service.GetAllAsync(
				paginationModel,
				cancellationToken);

			return OkPaged(
				products,
				paginationModel,
				itemsCount);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProductEntity>> GetById(
			string id,
			CancellationToken cancellationToken)
		{
			var product = await _service.GetItemByKeyAsync(id, cancellationToken);
			if (product == null)
			{
				return NotFound("Product was not found.");
			}

			return Ok(product);
		}

		[HttpGet("scrape")]
		public async Task<ActionResult<ProductEntity>> ScrapeWebPage(string url, CancellationToken ct)
		{
			var product = await _service.FetchProduct(url, ct);
			product = await _service.CreateAsync(product, ct);

			return Ok(product);
		}

		[HttpPost("loadVehicle")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> LoadVehicle(string vin, CancellationToken ct)
		{
			_logger.LogInformation("Load vehicle data by Vin");

			var vehicle = await _service.GetItemByKeyAsync(vin, ct);
			if (vehicle is null)
			{
				return NotFound("Vehicle was not loaded.");
			}

			return NoContent();
		}
	}
}
