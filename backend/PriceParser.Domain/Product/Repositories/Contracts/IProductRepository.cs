using PriceParser.Domain.Common.Repositories;
using PriceParser.Domain.Product.Entities;

namespace PriceParser.Domain.Product.Repositories.Contracts
{
	public interface IProductRepository : IBaseRepository<ProductEntity>
	{
	}
}
