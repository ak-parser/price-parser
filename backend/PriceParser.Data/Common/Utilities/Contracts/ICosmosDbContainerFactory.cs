using Microsoft.Azure.Cosmos;

namespace PriceParser.Data.Common.Utilities.Contracts
{
	public interface ICosmosDbContainerFactory
	{
		Task<Container> CreateContainer(string containerName, string partitionKey);
		Task<Container> GetContainer(string containerName);
		Task DeleteContainer(string containerName);
	}
}
