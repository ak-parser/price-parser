using Lynkco.Warranty.WebAPI.ProcessExternalData;
using Lynkco.Warranty.WebAPI.ProcessExternalData.Common.Config.Dependencies;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Lynkco.Warranty.WebAPI.ProcessExternalData
{
	internal class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			builder.Services.AddHttpClient();
			builder.Services.AddLogging();

			builder.Services.RegisterDependencies();
		}
	}
}
