using System.Diagnostics.CodeAnalysis;
using Lynkco.Warranty.WebAPI.Application.Common.AzureEventGrid.Service.Contracts;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Service;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Settings.Providers;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Settings.Providers.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Config
{
	[ExcludeFromCodeCoverage]
	public static class AzureEventGridDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddTransient<IEventGridService, AzureEventGridService>();
			services.AddScoped<IEventGridTopicSettingsProvider, AzureEventGridTopicSettingsProvider>();
		}
	}
}
