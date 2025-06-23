using PriceParser.Domain.Common.Entities.Contracts;

namespace PriceParser.Application.Common.Services.Contracts
{
	public interface IBaseInternalEntityService<TEntity> : IBaseEntityService<TEntity, string> where TEntity : IEntity
	{
	}
}
