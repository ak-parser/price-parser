using PriceParser.Data.Common.Repositories;
using PriceParser.Data.Common.Repositories.Const;
using PriceParser.Data.Common.Utilities.Contracts;
using PriceParser.Domain.Product.Entities;
using PriceParser.Domain.Product.Repositories.Contracts;

namespace PriceParser.Data.Product.Repository
{
	public class CosmosDbProductRepository : CosmosDbBaseRepository<ProductEntity>,
		IProductRepository
	{
		public CosmosDbProductRepository(ICosmosDbContainerFactory factory)
			: base(factory, ContainerNames.Product, ContainerPartitionKeys.PartitionKeys[ContainerNames.Product])
		{
		}
	}
}
