using PriceParser.Domain.Common.Repositories;
using PriceParser.Domain.User.Entity;

namespace PriceParser.Domain.User.Repository.Contracts
{
	public interface IUserRepository : IBaseRepository<UserEntity>
	{
	}
}
