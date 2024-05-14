using Lynkco.Warranty.WebAPI.Application.Common.Services;
using Lynkco.Warranty.WebAPI.Application.User.Service.Contracts;
using Lynkco.Warranty.WebAPI.Domain.User.Entity;
using Lynkco.Warranty.WebAPI.Domain.User.Repository.Contracts;

namespace Lynkco.Warranty.WebAPI.Application.User.Service
{
	public class UserManagementEntityService : BaseInternalEntityService<UserEntity>, IUserManagementEntityService
	{

		public UserManagementEntityService(
			IUserRepository repository) : base(repository)
		{
		}

		public async Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken ct)
		{
			return await base.CreateAsync(user, ct);
		}

		public async Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken ct)
		{
			return await base.UpdateAsync(user, ct);
		}
	}
}
