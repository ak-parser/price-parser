using System.Diagnostics.CodeAnalysis;
using PriceParser.Application.Common.Config.Dependencies;
using PriceParser.Data.Common.Config.Dependencies;
using PriceParser.Host.Product.Config;
using PriceParser.Host.User.Config;
using PriceParser.Infrastructure.Common.Config.Dependencies;

namespace PriceParser.Host.Common.Config.Dependencies
{
	[ExcludeFromCodeCoverage]
	public static class DependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			ApplicationDependencyRegistrator.RegisterDependencies(services);
			DataDependencyRegistrator.RegisterDependencies(services);
			InfrastructureDependencyRegistrator.RegisterDependencies(services);

			ProductDependencyRegistrator.RegisterDependencies(services);
			UserDependencyRegistrator.RegisterDependencies(services);

			// Common
			services.AddLocalization(opts =>
			{
				opts.ResourcesPath = string.Empty;
			});
		}
	}
}
