using PriceParser.Application.Common.Services.Contracts;
using PriceParser.Domain.Common.Entities.Contracts;
using PriceParser.Domain.Common.Repositories;

namespace PriceParser.Application.Common.Services
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
