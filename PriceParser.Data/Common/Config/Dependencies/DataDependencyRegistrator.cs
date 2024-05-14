using Lynkco.Warranty.WebAPI.Data.Common.Utilities;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Data.User.Config;
using Lynkco.Warranty.WebAPI.Data.VehicleWarranty.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Data.Common.Config.Dependencies
{
	[ExcludeFromCodeCoverage]
	public static class DataDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			ProductDependencyRegistrator.RegisterDependencies(services);
			UserDependencyRegistrator.RegisterDependencies(services);

			// Common
			services.AddSingleton<ICosmosDbContainerFactory, CosmosDbContainerFactory>();
			services.AddTransient<IPredicateBuilder, PredicateBuilder>();
		}
	}
}
