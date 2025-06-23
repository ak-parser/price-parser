using Newtonsoft.Json;
using PriceParser.Application.Common.Mapper.Contracts;
using PriceParser.Application.Common.Services;
using PriceParser.Application.Product.Models;
using PriceParser.Application.Product.Service.Contracts;
using PriceParser.Domain.Product.Entities;
using PriceParser.Domain.Product.Repositories.Contracts;

namespace PriceParser.Application.Product.Service
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

			var amazonProduct = JsonConvert.DeserializeObject<AmazonProductModel>(data);
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
