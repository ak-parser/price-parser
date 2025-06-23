using PriceParser.Data.Common.Repositories;
using PriceParser.Data.Common.Repositories.Const;
using PriceParser.Data.Common.Utilities.Contracts;
using PriceParser.Domain.User.Entity;
using PriceParser.Domain.User.Repository.Contracts;

namespace PriceParser.Data.User.Repository
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
