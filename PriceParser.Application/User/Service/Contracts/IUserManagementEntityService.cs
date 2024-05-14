using Lynkco.Warranty.WebAPI.Application.Common.Services.Contracts;
using Lynkco.Warranty.WebAPI.Domain.User.Entity;

namespace Lynkco.Warranty.WebAPI.Application.User.Service.Contracts
{
	public interface IUserManagementEntityService : IBaseInternalEntityService<UserEntity>
	{
		public Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken ct);
		public Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken ct);
	}
}
