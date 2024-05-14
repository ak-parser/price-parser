using Lynkco.Warranty.WebAPI.Application.Common.Services.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Entities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Pagination.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Repositories;
using Microsoft.Azure.Cosmos;
using System.Linq.Expressions;

namespace Lynkco.Warranty.WebAPI.Application.Common.Services
{
	public abstract class BaseEntityService<TEntity, TRequestModel> : IBaseEntityService<TEntity, TRequestModel>
		where TEntity : IEntity
	{
		private readonly IBaseRepository<TEntity> _repository;

		public BaseEntityService(IBaseRepository<TEntity> repository)
		{
			_repository = repository;
		}

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct)
			=> await _repository.GetAllAsync(ct);

		public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
			IPaginationParameters pagination,
			CancellationToken cancellationToken)
			=> await _repository.GetAllAsync(pagination, cancellationToken);

		public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken ct)
			=> await _repository.CreateAsync(entity, ct);

		public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
			=> await _repository.UpdateAsync(entity, cancellationToken);

		public virtual Task<TEntity> UpdateConcurrentAsync(TEntity entity, CancellationToken cancellationToken)
			=> _repository.UpdateConcurrentAsync(entity, cancellationToken);

		public virtual async Task DeleteAsync(TRequestModel model, CancellationToken cancellationToken)
			=> await _repository.DeleteAsync(GetItemId(model), cancellationToken);

		public virtual async Task<TEntity> GetItemByKeyAsync(TRequestModel model, CancellationToken cancellationToken)
			=> await _repository.GetItemByKeyAsync(GetItemKey(model), cancellationToken);

		public virtual async Task<IEnumerable<TEntity>> GetItemsByKeyAsync(string key, CancellationToken cancellationToken)
			=> await _repository.GetItemsByKeyAsync(key, cancellationToken);

		public virtual async Task<TEntity> GetByIdAsync(TRequestModel model, CancellationToken cancellationToken)
			=> await _repository.GetByIdAsync(GetItemId(model), cancellationToken);

		public virtual Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<TRequestModel> models, CancellationToken cancellationToken)
			=> _repository.GetByIdsAsync(models.Select(x => GetItemId(x)), cancellationToken);

		public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
			=> await _repository.FindAsync(filter, cancellationToken);

		public virtual Task<IEnumerable<TEntity>> FindAsync(
			Expression<Func<TEntity, bool>> filter,
			IPaginationParameters pagination,
			CancellationToken cancellationToken)
			=> _repository.FindAsync(filter, pagination, cancellationToken);

		public virtual async Task<int> GetCount(CancellationToken cancellationToken)
			=> await _repository.GetCount(cancellationToken);

		public virtual async Task<int> GetCount(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
			=> await _repository.GetCount(expression, cancellationToken);

		public virtual async Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, TResult>> selector,
			CancellationToken cancellationToken,
			bool distinct = false)
			=> await _repository.SelectAsync(selector, cancellationToken, distinct);

		public virtual async Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, TResult>> selector,
			CancellationToken cancellationToken,
			bool distinct = false)
			=> await _repository.SelectAsync(filter, selector, cancellationToken, distinct);

		public virtual async Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, TResult>> selector,
			IPaginationParameters pagination,
			CancellationToken cancellationToken,
			bool distinct = false)
			=> await _repository.SelectAsync(filter, selector, pagination, cancellationToken, distinct);

		public virtual async Task<TEntity> PatchUpdateAsync(TRequestModel model, List<PatchOperation> operations, CancellationToken ct)
			=> await _repository.PatchUpdateAsync(GetItemId(model), operations, ct);

		protected abstract string GetItemId(TRequestModel model);
		protected abstract string GetItemKey(TRequestModel model);
	}
}
