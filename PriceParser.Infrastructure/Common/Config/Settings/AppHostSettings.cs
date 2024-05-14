using System.Globalization;
using Lynkco.Warranty.WebAPI.Application.Common.Utilities.Contracts;
using Microsoft.Extensions.Configuration;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Config.Settings
{
	public class AppHostSettings : IAppHostSettings
	{
		private const string SectionName = "WebApp";
		private readonly IConfiguration _configuration;

		public AppHostSettings(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string HostUrl => Setting<string>("Uri");

		private T Setting<T>(string name)
		{
			var value = _configuration[$"{SectionName}:{name}"];

			if (value == null)
			{
				throw new ApplicationException($"Could not find setting '{name}'");
			}

			return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
		}
	}
}
