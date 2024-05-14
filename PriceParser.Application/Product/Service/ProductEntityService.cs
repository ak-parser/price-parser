using Lynkco.Warranty.WebAPI.Application.Common.Mapper.Contracts;
using Lynkco.Warranty.WebAPI.Application.Common.Services;
using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Models;
using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Service.Contracts;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Repositories.Contracts;
using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Service
{
	public class ProductEntityService : BaseInternalEntityService<ProductEntity>, IProductEntityService
	{
		private readonly IZenRowsService _zenService;
		private readonly IMapper<AmazonProductModel, ProductEntity> _mapper;

		public ProductEntityService(
			IProductRepository repository, IZenRowsService zenService, IMapper<AmazonProductModel, ProductEntity> mapper)
			: base(repository)
		{
			_zenService = zenService;
			_mapper = mapper;
		}

		public override async Task<ProductEntity> CreateAsync(ProductEntity vehicle, CancellationToken ct)
		{
			var createdVehicle = await base.CreateAsync(vehicle, ct);
			return createdVehicle;
		}

		public override async Task<ProductEntity> UpdateAsync(ProductEntity vehicleWarranty, CancellationToken ct)
			=> await UpdateAsync(vehicleWarranty, false, ct);

		public async Task<ProductEntity> UpdateAsync(ProductEntity vehicle, bool triggerUpdateEvent, CancellationToken ct)
		{
			var updatedVehicle = await base.UpdateAsync(vehicle, ct);
			return updatedVehicle;
		}

		public async Task<ProductEntity> FetchProduct(string url, CancellationToken ct)
		{
			var data = await _zenService.ScrapeAsync(url);

			AmazonProductModel amazonProduct = JsonConvert.DeserializeObject<AmazonProductModel>(data);
			var product = _mapper.Map(amazonProduct);

			return product;
		}
	}
}
