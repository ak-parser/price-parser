using Microsoft.Azure.Cosmos;

namespace Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts
{
	public interface ICosmosDbContainerFactory
	{
		Task<Container> CreateContainer(string containerName, string partitionKey);
		Task<Container> GetContainer(string containerName);
		Task DeleteContainer(string containerName);
	}
}
