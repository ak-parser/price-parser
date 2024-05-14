using System.Globalization;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Microsoft.Extensions.Configuration;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Config.Settings
{
	public class CosmosDbSettings : ICosmosDbSettings
	{
		private const string CosmosDbSectionName = "CosmosDb";

		private readonly IConfiguration _configuration;

		public CosmosDbSettings(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string DatabaseId => Setting<string>("DatabaseId");

		public string ConnectionString => Setting<string>("ConnectionString");
		public TimeSpan RequestTimeout => TimeSpan.FromSeconds(Setting<int>("RequestTimeout"));
		public int MaxRetryAttemptsOnRateLimitedRequests => Setting<int>("MaxRetryAttemptsOnRateLimitedRequests");
		public TimeSpan MaxRetryWaitTimeOnRateLimitedRequests
			=> TimeSpan.FromSeconds(Setting<int>("MaxRetryWaitTimeOnRateLimitedRequests"));

		private T Setting<T>(string name)
		{
			var value = _configuration[$"{CosmosDbSectionName}:{name}"];

			if (value == null)
			{
				throw new ApplicationException($"Could not find setting '{name}'");
			}

			return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
		}
	}
}
