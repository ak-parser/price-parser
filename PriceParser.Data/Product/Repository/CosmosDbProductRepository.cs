using Lynkco.Warranty.WebAPI.Data.Common.Repositories;
using Lynkco.Warranty.WebAPI.Data.Common.Repositories.Const;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Repositories.Contracts;

namespace Lynkco.Warranty.WebAPI.Data.VehicleWarranty.Repository
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
