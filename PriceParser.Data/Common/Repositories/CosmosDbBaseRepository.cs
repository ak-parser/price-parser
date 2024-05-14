using Lynkco.Warranty.WebAPI.Data.Common.Exceptions;
using Lynkco.Warranty.WebAPI.Data.Common.Repositories.Const;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Entities;
using Lynkco.Warranty.WebAPI.Domain.Common.Entities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Pagination.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;

namespace Lynkco.Warranty.WebAPI.Data.Common.Repositories
{
	public abstract class CosmosDbBaseRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity : IEntity
	{
		private readonly ICosmosDbContainerFactory _factory;
		private Container _container;

		protected CosmosDbBaseRepository(
			ICosmosDbContainerFactory factory,
			string containerName,
			string partitionKey)
		{
			_factory = factory;

			ContainerName = containerName;
			PartitionKey = partitionKey;
		}

		protected internal string ContainerName { get; init; }
		protected string PartitionKey { get; init; }

		public async Task<TEntity> PatchUpdateAsync(string id, List<PatchOperation> operations, CancellationToken ct)
		{
			var container = await GetContainer();
			var response = await container.PatchItemAsync<TEntity>(
				id: id,
				partitionKey: new PartitionKey(id),
				patchOperations: operations);

			return response.Resource;
		}

		public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
		{
			if (string.IsNullOrEmpty(entity.Id))
			{
				entity.Id = Guid.NewGuid().ToString();
			}

			var container = await GetContainer();
			var response =
				await container.CreateItemAsync(entity,
						GetPartitionKey(entity),
						cancellationToken: cancellationToken)
					.ConfigureAwait(false);

			return response.Resource;
		}

		public async Task DeleteAsync(string id, CancellationToken cancellationToken)
		{
			var container = await GetContainer();
			var entity = await GetItemByKeyAsync(id, cancellationToken);

			await container.DeleteItemAsync<TEntity>(id,
					GetPartitionKey(entity),
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);
		}

		public async Task<IEnumerable<TEntity>> FindAsync(
			Expression<Func<TEntity, bool>> expression,
			IPaginationParameters pagination,
			CancellationToken cancellationToken)
			=> await SelectItemsAsync(expression, pagination, cancellationToken);

		public async Task<IEnumerable<TEntity>> FindAsync(
			Expression<Func<TEntity, bool>> filter,
			CancellationToken cancellationToken) =>
			await SelectItemsAsync(filter, null, cancellationToken);

		public async Task<IEnumerable<TEntity>> GetAllAsync(
			IPaginationParameters pagination,
			CancellationToken cancellationToken)
			=> await SelectItemsAsync(null, pagination, cancellationToken);

		public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
			=> await SelectItemsAsync(cancellationToken: cancellationToken);

		public async Task<TEntity> GetItemByKeyAsync(string keyValue, CancellationToken cancellationToken)
			=> (await GetItemsByKeyAsync(keyValue, cancellationToken)).FirstOrDefault();

		public async Task<IEnumerable<TEntity>> GetItemsByKeyAsync(string keyValue, CancellationToken cancellationToken)
		{
			var container = await GetContainer();
			var queryDefinition = new QueryDefinition("SELECT * FROM c");
			var iterator = container.GetItemQueryIterator<TEntity>(
				queryDefinition,
				requestOptions: new QueryRequestOptions()
				{
					PartitionKey = new PartitionKey(keyValue)
				});

			var results = new List<TEntity>();
			while (iterator.HasMoreResults)
			{
				var result = await iterator.ReadNextAsync(cancellationToken);
				results.AddRange(result.Resource);
			}

			return results;
		}

		public async Task<TEntity> GetByIdAsync(
			string id,
			CancellationToken cancellationToken)
		{
			if (PartitionKey.Equals(nameof(BaseEntity.Id), StringComparison.OrdinalIgnoreCase))
			{
				return await GetItemByKeyAsync(id, cancellationToken);
			}

			var container = await GetContainer();
			return container.GetItemLinqQueryable<TEntity>()
				.Where(e => e.Id == id)
				.FirstOrDefault();
		}

		public async Task<IEnumerable<TEntity>> GetByIdsAsync(
			IEnumerable<string> ids,
			CancellationToken cancellationToken)
		{
			var container = await GetContainer();

			if (PartitionKey.Equals(nameof(BaseEntity.Id), StringComparison.OrdinalIgnoreCase))
			{
				var itemList = new List<(string, PartitionKey)>();
				foreach (var id in ids)
				{
					itemList.Add((id, new PartitionKey(PartitionKey)));
				}

				var result = await container.ReadManyItemsAsync<TEntity>(
					itemList,
					null,
					cancellationToken)
					.ConfigureAwait(false);

				return result;
			}

			return await FindAsync(e => ids.Contains(e.Id), cancellationToken);
		}

		public async Task<int> GetCount(Expression<Func<TEntity, bool>> expression,
			CancellationToken cancellationToken)
		{
			var container = await GetContainer();
			return await container.GetItemLinqQueryable<TEntity>()
				.Where(expression)
				.CountAsync(cancellationToken)
				.ConfigureAwait(false);
		}

		public async Task<int> GetCount(CancellationToken cancellationToken)
		{
			var container = await GetContainer();
			return await container.GetItemLinqQueryable<TEntity>()
				.CountAsync(cancellationToken)
				.ConfigureAwait(false);
		}

		public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
		{
			var container = await GetContainer();

			try
			{
				var response =
				await container.ReplaceItemAsync(
					entity,
					entity.Id,
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);

				return response.Resource;
			}
			catch (CosmosException ex)
			{
				if (ex.StatusCode == HttpStatusCode.NotFound)
				{
					throw new ItemNotFoundException(CosmosDbMessages.ItemNotFoundErrorMessage);
				}
				else
				{
					throw new Exception($"StatusCode: {ex.StatusCode}; Message: {ex.Message}");
				}
			}
		}

		public virtual async Task<TEntity> UpdateConcurrentAsync(TEntity entity, CancellationToken cancellationToken)
		{
			var container = await GetContainer();
			var requestOptions = new ItemRequestOptions()
			{
				IfMatchEtag = entity.ETag
			};

			try
			{
				var response =
					await container.ReplaceItemAsync(
						entity,
						entity.Id,
						requestOptions: requestOptions,
						cancellationToken: cancellationToken)
					.ConfigureAwait(false);

				return response.Resource;
			}
			catch (CosmosException ex)
			{
				if (ex.StatusCode == HttpStatusCode.NotFound)
				{
					throw new ItemNotFoundException(CosmosDbMessages.ItemNotFoundErrorMessage);
				}
				else if (ex.StatusCode == HttpStatusCode.PreconditionFailed)
				{
					return default;
				}

				throw new Exception($"StatusCode: {ex.StatusCode}; Message: {ex.Message}");
			}
		}

		public async Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, TResult>> selector,
			CancellationToken cancellationToken,
			bool distinct = false)
			=> await SelectAsync(null, selector, cancellationToken, distinct);

		public async Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> predicate,
			Expression<Func<TEntity, TResult>> selector,
			CancellationToken cancellationToken,
			bool distinct = false)
			=> await SelectAsync(predicate, selector, null, cancellationToken, distinct);

		public async Task<IEnumerable<TResult>> SelectAsync<TResult>(
			Expression<Func<TEntity, bool>> predicate,
			Expression<Func<TEntity, TResult>> selector,
			IPaginationParameters pagination,
			CancellationToken cancellationToken,
			bool distinct = false)
		{
			var container = await GetContainer();
			IQueryable<TEntity> query = container.GetItemLinqQueryable<TEntity>();
			if (predicate is not null)
			{
				query = query.Where(predicate);
			}

			IQueryable<TResult> query2 = null;
			if (selector is not null)
			{
				query2 = query.Select(selector);
			}

			if (distinct)
			{
				query2 = query2.Distinct();
			}

			if (pagination is not null)
			{
				query2 = query2
					.Skip((pagination.PageNumber - 1) * pagination.PageSize)
					.Take(pagination.PageSize);
			}

			using var setIterator = query2.ToFeedIterator();
			var result = new List<TResult>();

			while (setIterator.HasMoreResults)
			{
				result.AddRange(await setIterator.ReadNextAsync(cancellationToken));
			}

			return result;
		}

		protected async Task<Container> GetContainer()
		{
			if (_container is null)
			{
				_container = await _factory.GetContainer(ContainerName);
			}

			return _container;
		}

		protected PartitionKey GetPartitionKey(TEntity entity)
		{
			var type = entity.GetType();
			var property = type.GetProperty(PartitionKey,
				BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
			return property is null
				? Microsoft.Azure.Cosmos.PartitionKey.None
				: new PartitionKey(property.GetValue(entity)?.ToString());
		}

		private async Task<IEnumerable<TEntity>> SelectItemsAsync(
			Expression<Func<TEntity, bool>> predicate = null,
			IPaginationParameters pagination = null,
			CancellationToken cancellationToken = default)
		{
			var container = await GetContainer();
			IQueryable<TEntity> query = container.GetItemLinqQueryable<TEntity>();

			if (predicate is not null)
			{
				query = query.Where(predicate);
			}

			if (pagination is not null)
			{
				query = query
					.Skip((pagination.PageNumber - 1) * pagination.PageSize)
					.Take(pagination.PageSize);
			}

			using var setIterator = query.ToFeedIterator();
			var result = new List<TEntity>();

			while (setIterator.HasMoreResults)
			{
				result.AddRange(await setIterator.ReadNextAsync(cancellationToken));
			}

			return result;
		}
	}
}
