using Lynkco.Warranty.WebAPI.Application.Common.Config.Dependencies;
using Lynkco.Warranty.WebAPI.Data.Common.Config.Dependencies;
using Lynkco.Warranty.WebAPI.Host.User.Config;
using Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Config;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Config.Dependencies;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Host.Common.Config.Dependencies
{
	[ExcludeFromCodeCoverage]
	public static class DependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			ApplicationDependencyRegistrator.RegisterDependencies(services);
			DataDependencyRegistrator.RegisterDependencies(services);
			InfrastructureDependencyRegistrator.RegisterDependencies(services);

			VehicleWarrantyDependencyRegistrator.RegisterDependencies(services);
			UserDependencyRegistrator.RegisterDependencies(services);

			// Common
			services.AddLocalization(opts =>
			{
				opts.ResourcesPath = string.Empty;
			});
		}
	}
}
