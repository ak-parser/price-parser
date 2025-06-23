using PriceParser.Application.Common.Services.Contracts;
using PriceParser.Domain.Product.Entities;

namespace PriceParser.Application.Product.Service.Contracts
{
	public interface IProductEntityService : IBaseInternalEntityService<ProductEntity>
	{
		public Task<ProductEntity> FetchProduct(string url, CancellationToken ct);
		public Task<ProductEntity> ScrapeProduct(string url, CancellationToken ct);
	}
}
