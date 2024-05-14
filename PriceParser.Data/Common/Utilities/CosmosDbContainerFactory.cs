using System.Diagnostics.CodeAnalysis;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Microsoft.Azure.Cosmos;

namespace Lynkco.Warranty.WebAPI.Data.Common.Utilities
{
	[ExcludeFromCodeCoverage]
	public class CosmosDbContainerFactory : ICosmosDbContainerFactory
	{
		private readonly CosmosClient _cosmosClient;
		private readonly string _databaseId;

		public CosmosDbContainerFactory(ICosmosDbSettings dbSettings)
		{
			_cosmosClient = new CosmosClient(dbSettings.ConnectionString, new CosmosClientOptions()
			{
				AllowBulkExecution = true,
				RequestTimeout = dbSettings.RequestTimeout,
				MaxRetryAttemptsOnRateLimitedRequests = dbSettings.MaxRetryAttemptsOnRateLimitedRequests,
				MaxRetryWaitTimeOnRateLimitedRequests = dbSettings.MaxRetryWaitTimeOnRateLimitedRequests,
			});
			_databaseId = dbSettings.DatabaseId;
		}

		public async Task<Container> CreateContainer(string containerName, string partitionKey)
		{
			var database = _cosmosClient.GetDatabase(_databaseId);
			var container = await database.CreateContainerIfNotExistsAsync(containerName,
				$"/{partitionKey}");

			return container;
		}

		public async Task<Container> GetContainer(string containerName)
		{
			var database = _cosmosClient.GetDatabase(_databaseId);
			var container = database.GetContainer(containerName);

			return container;
		}

		public async Task DeleteContainer(string containerName)
		{
			var database = _cosmosClient.GetDatabase(_databaseId);
			var container = database.GetContainer(containerName);
			await container.DeleteContainerAsync();
		}
	}
}
