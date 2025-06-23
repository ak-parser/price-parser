using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Common.Config.Dependencies;
using PriceParser.Data.Common.Config.Dependencies;
using PriceParser.Infrastructure.Common.Config.Dependencies;

namespace PriceParser.ProcessExternalData.Common.Config.Dependencies
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
