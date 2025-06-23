using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Common.AzureEventGrid.Service.Contracts;
using PriceParser.Infrastructure.Common.AzureEventGrid.Service;
using PriceParser.Infrastructure.Common.AzureEventGrid.Settings.Providers;
using PriceParser.Infrastructure.Common.AzureEventGrid.Settings.Providers.Contracts;

namespace PriceParser.Infrastructure.Common.AzureEventGrid.Config
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
