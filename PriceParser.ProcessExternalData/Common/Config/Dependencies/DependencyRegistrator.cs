using Lynkco.Warranty.WebAPI.Application.Common.Config.Dependencies;
using Lynkco.Warranty.WebAPI.Data.Common.Config.Dependencies;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Config.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.ProcessExternalData.Common.Config.Dependencies
{
	[ExcludeFromCodeCoverage]
	public static class DependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			ApplicationDependencyRegistrator.RegisterDependencies(services);
			DataDependencyRegistrator.RegisterDependencies(services);
			InfrastructureDependencyRegistrator.RegisterDependencies(services);
		}
	}
}
