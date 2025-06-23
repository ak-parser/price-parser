using System.Reflection;
using PriceParser.Data.Common.Repositories.Const;
using PriceParser.Data.Common.Utilities.Contracts;
using PriceParser.Infrastructure.Common.Utilities.Contracts;

namespace PriceParser.Infrastructure.Common.Utilities
{
	public class CosmosDbContainersHandler : ICosmosDbContainersHandler
	{
		private readonly ICosmosDbContainerFactory _factory;

		public CosmosDbContainersHandler(ICosmosDbContainerFactory factory)
		{
			_factory = factory;
		}

		public async Task CreateAllContainers()
		{
			var containerNames = typeof(ContainerNames).GetFields(BindingFlags.Public | BindingFlags.Static)
				.Select(x => (string)x.GetRawConstantValue());

			foreach (var containerName in containerNames)
			{
				await _factory.CreateContainer(containerName, ContainerPartitionKeys.PartitionKeys[containerName]);
			}
		}
	}
}
