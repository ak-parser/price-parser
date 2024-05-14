using Lynkco.Warranty.WebAPI.Application.Common.Authentication.Settings.Models;
using Lynkco.Warranty.WebAPI.Application.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Data.Common.Pagination;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Pagination.Contracts;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Authentication.Settings;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Config;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Config.Settings;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.RequestPolicies.Config;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Utilities;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Config.Dependencies
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
