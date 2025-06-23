using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Common.Authentication.Settings.Models;
using PriceParser.Application.Common.Utilities.Contracts;
using PriceParser.Data.Common.Pagination;
using PriceParser.Data.Common.Utilities.Contracts;
using PriceParser.Domain.Common.Pagination.Contracts;
using PriceParser.Infrastructure.Common.Authentication.Settings;
using PriceParser.Infrastructure.Common.AzureEventGrid.Config;
using PriceParser.Infrastructure.Common.Config.Settings;
using PriceParser.Infrastructure.Common.RequestPolicies.Config;
using PriceParser.Infrastructure.Common.Utilities;
using PriceParser.Infrastructure.Common.Utilities.Contracts;

namespace PriceParser.Infrastructure.Common.Config.Dependencies
{
	[ExcludeFromCodeCoverage]
	public static class InfrastructureDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			AzureEventGridDependencyRegistrator.RegisterDependencies(services);
			HttpRetryPolicyConfigRegistrator.AddHttpClients(services);

			// Common
			services.AddTransient<ICosmosDbSettings, CosmosDbSettings>();
			services.AddTransient<IConfigProvider<AuthenticationSettings>, AuthenticationConfigProvider>();
			services.AddTransient<IPaginationParameters, PaginationParametersModel>();
			services.AddTransient<ITimezoneOffsetProvider, TimezoneOffsetProvider>();
			services.AddTransient<ISecondsToMinutesCalculator, SecondsToMinutesCalculator>();
			services.AddTransient<ICosmosDbContainersHandler, CosmosDbContainersHandler>();
			services.AddTransient<IAppHostSettings, AppHostSettings>();
		}
	}
}
