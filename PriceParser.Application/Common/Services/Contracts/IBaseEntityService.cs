using System.Linq.Expressions;
using Microsoft.Azure.Cosmos;
using PriceParser.Domain.Common.Entities.Contracts;
using PriceParser.Domain.Common.Pagination.Contracts;

namespace PriceParser.Application.Common.Services.Contracts
{
	public interface IBaseEntityService<TEntity, TRequestModel> where TEntity : IEntity
	{
		Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
		Task<IEnumerable<TEntity>> GetAllAsync(
			IPaginationParameters pagination,
			CancellationToken ct);
		Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct);

		Task<TEntity> UpdateAsync(TEntity entity, CancellationToken ct);
		Task<TEntity> UpdateConcurrentAsync(TEntity entity, CancellationToken ct);

		Task<TEntity> PatchUpdateAsync(TRequestModel model, List<PatchOperation> operations, CancellationToken ct);

		Task DeleteAsync(TRequestModel model, CancellationToken ct);

		Task<TEntity> GetItemByKeyAsync(TRequestModel model, CancellationToken ct);
		Task<IEnumerable<TEntity>> GetItemsByKeyAsync(string key, CancellationToken ct);

		Task<TEntity> GetByIdAsync(TRequestModel model, CancellationToken ct);
		Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TRequestModel> models, CancellationToken ct);

		Task<IEnumerable<TEntity>> FindAsync(
			Expression<Func<TEntity, bool>> filter,
			CancellationToken ct);
		Task<IEnumerable<TEntity>> FindAsync(
			Expression<Func<TEntity, bool>> filter,
			IPaginationParameters pagination,
			CancellationToken ct);

		Task<int> GetCount(CancellationToken ct);
		Task<int> GetCount(Expression<Func<TEntity, bool>> expression, CancellationToken ct);

		Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, TResult>> selector,
			CancellationToken ct,
			bool distinct = false);
		Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, TResult>> selector,
			CancellationToken ct,
			bool distinct = false);

		Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, TResult>> selector,
			IPaginationParameters pagination,
			CancellationToken ct,
			bool distinct = false);
	}
}
