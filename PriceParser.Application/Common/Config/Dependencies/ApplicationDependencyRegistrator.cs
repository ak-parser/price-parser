using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Common.Authentication.Config;
using PriceParser.Application.Common.Utilities.Config;
using PriceParser.Application.Product.Config;
using PriceParser.Application.User.Config;

namespace PriceParser.Application.Common.Config.Dependencies
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
