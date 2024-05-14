using Lynkco.Warranty.WebAPI.Data.Common.Repositories;
using Lynkco.Warranty.WebAPI.Data.Common.Repositories.Const;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.User.Entity;
using Lynkco.Warranty.WebAPI.Domain.User.Repository.Contracts;

namespace Lynkco.Warranty.WebAPI.Data.User.Repository
{
	public class CosmosDbUserRepository : CosmosDbBaseRepository<UserEntity>,
		IUserRepository
	{
		public CosmosDbUserRepository(ICosmosDbContainerFactory factory)
			: base(factory, ContainerNames.User, ContainerPartitionKeys.PartitionKeys[ContainerNames.User])
		{
		}
	}
}
