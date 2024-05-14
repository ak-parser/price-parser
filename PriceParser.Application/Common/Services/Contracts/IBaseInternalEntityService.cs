using Lynkco.Warranty.WebAPI.Domain.Common.Entities.Contracts;

namespace Lynkco.Warranty.WebAPI.Application.Common.Services.Contracts
{
	public interface IBaseInternalEntityService<TEntity> : IBaseEntityService<TEntity, string> where TEntity : IEntity
	{
	}
}
