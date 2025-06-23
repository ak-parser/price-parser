using PriceParser.Application.Common.Services.Contracts;
using PriceParser.Domain.User.Entity;

namespace PriceParser.Application.User.Service.Contracts
{
	public interface IUserManagementEntityService : IBaseInternalEntityService<UserEntity>
	{
		public Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken ct);
		public Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken ct);
	}
}
