namespace Lynkco.Warranty.WebAPI.Data.Common.Repositories.Const
{
	public static class ContainerPartitionKeys
	{
		public static readonly IReadOnlyDictionary<string, string> PartitionKeys = new Dictionary<string, string>()
		{
			{ ContainerNames.Product, "id" },
			{ ContainerNames.User, "id" },
		};
	}
}
