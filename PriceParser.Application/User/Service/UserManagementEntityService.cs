using PriceParser.Application.Common.Services;
using PriceParser.Application.User.Service.Contracts;
using PriceParser.Domain.User.Entity;
using PriceParser.Domain.User.Repository.Contracts;

namespace PriceParser.Application.User.Service
{
	public class UserManagementEntityService : BaseInternalEntityService<UserEntity>, IUserManagementEntityService
	{
		public UserManagementEntityService(
			IUserRepository repository) : base(repository)
		{
		}

		public async Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken ct)
		{
			return await CreateAsync(user, ct);
		}

		public async Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken ct)
		{
			return await UpdateAsync(user, ct);
		}
	}
}
