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

		public override async Task<ProductEntity> UpdateAsync(ProductEntity vehicle, CancellationToken ct)
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

		public async Task<ProductEntity> ScrapeProduct(string url, CancellationToken ct)
		{
			var product = await FetchProduct(url, ct);
			product.Url = url;

			var existingProduct = (await FindAsync(x => x.Url == url, ct)).FirstOrDefault();
			if (existingProduct is null)
			{
				product = await CreateAsync(product, ct);
			}
			else
			{
				product.Id = existingProduct.Id;
				product.UserEmail = existingProduct.UserEmail;
				product.PriceHistory = existingProduct.PriceHistory.Concat(product.PriceHistory).ToList();
				product = await UpdateAsync(product, ct);
			}

			return product;
		}
	}
}
