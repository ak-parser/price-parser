using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.ProcessExternalData;
using PriceParser.ProcessExternalData.Common.Config.Dependencies;

[assembly: FunctionsStartup(typeof(Startup))]
namespace PriceParser.ProcessExternalData
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
