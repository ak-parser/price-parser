namespace PriceParser.Infrastructure.Common.Utilities.Contracts
{
	public interface ICosmosDbContainersHandler
	{
		public Task CreateAllContainers();
	}
}
