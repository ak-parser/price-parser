using System.Diagnostics.CodeAnalysis;
using Lynkco.Warranty.WebAPI.Application.Common.Authentication.Config;
using Lynkco.Warranty.WebAPI.Application.Common.Utilities.Config;
using Lynkco.Warranty.WebAPI.Application.User.Config;
using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Lynkco.Warranty.WebAPI.Application.Common.Config.Dependencies
{
	[ExcludeFromCodeCoverage]
	public static class ApplicationDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			ProductDependencyRegistrator.RegisterDependencies(services);
			UserDependencyRegistrator.RegisterDependencies(services);

			AuthenticationDependencyRegistrator.RegisterDependencies(services);

			UtilitiesDependencyRegistrator.RegisterDependencies(services);

			services.AddSingleton<IZenRowsService>(provider => new ZenRowsService("bc329e5858199aa4a5581b70d86b9ec28cc39207"));
		}
	}
}
