using Microsoft.Extensions.DependencyInjection;
using PriceParser.Data.Common.Utilities;
using PriceParser.Data.Common.Utilities.Contracts;
using PriceParser.Data.Product.Config;
using PriceParser.Data.User.Config;
using System.Diagnostics.CodeAnalysis;

namespace PriceParser.Data.Common.Config.Dependencies
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
