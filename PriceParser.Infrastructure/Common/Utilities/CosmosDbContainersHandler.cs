using System.Reflection;
using Lynkco.Warranty.WebAPI.Data.Common.Repositories.Const;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Utilities.Contracts;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Utilities
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
