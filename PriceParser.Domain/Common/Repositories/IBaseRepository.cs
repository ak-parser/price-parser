using Lynkco.Warranty.WebAPI.Domain.Common.Entities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Pagination.Contracts;
using Microsoft.Azure.Cosmos;
using System.Linq.Expressions;

namespace Lynkco.Warranty.WebAPI.Domain.Common.Repositories
{
	public interface IBaseRepository<TEntity> where TEntity : IEntity
	{
		Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> GetAllAsync(
			IPaginationParameters pagination,
			CancellationToken cancellationToken);
		Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);

		Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
		Task<TEntity> UpdateConcurrentAsync(TEntity entity, CancellationToken cancellationToken);

		Task DeleteAsync(string id, CancellationToken cancellationToken);

		Task<TEntity> GetItemByKeyAsync(string key, CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> GetItemsByKeyAsync(string key, CancellationToken cancellationToken);

		Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<string> ids, CancellationToken cancellationToken);

		Task<IEnumerable<TEntity>> FindAsync(
			Expression<Func<TEntity, bool>> filter,
			CancellationToken cancellationToken);
		Task<IEnumerable<TEntity>> FindAsync(
			Expression<Func<TEntity, bool>> filter,
			IPaginationParameters pagination,
			CancellationToken cancellationToken);

		Task<int> GetCount(CancellationToken cancellationToken);
		Task<int> GetCount(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

		Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, TResult>> selector,
			CancellationToken cancellationToken,
			bool distinct = false);
		Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, TResult>> selector,
			CancellationToken cancellationToken,
			bool distinct = false);

		Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, TResult>> selector,
			IPaginationParameters pagination,
			CancellationToken cancellationToken,
			bool distinct = false);

		Task<TEntity> PatchUpdateAsync(string id, List<PatchOperation> operations, CancellationToken ct);
	}
}
