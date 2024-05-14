using Lynkco.Warranty.WebAPI.Application.Common.Services.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Entities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Repositories;

namespace Lynkco.Warranty.WebAPI.Application.Common.Services
{
	public abstract class BaseInternalEntityService<TEntity>
		: BaseEntityService<TEntity, string>, IBaseInternalEntityService<TEntity>
		where TEntity : IEntity
	{
		public BaseInternalEntityService(IBaseRepository<TEntity> repository) : base(repository)
		{
		}

		protected override string GetItemId(string model)
			=> model;

		protected override string GetItemKey(string model)
			=> model;
	}
}
