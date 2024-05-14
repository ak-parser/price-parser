using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Config.Settings
{
	public class BaseAppSettingsProvider
	{
		private readonly IConfiguration _configuration;
		private readonly string _sectionName;

		public BaseAppSettingsProvider(IConfiguration configuration, string sectionName)
		{
			_configuration = configuration;
			_sectionName = sectionName;
		}

		protected T Setting<T>(string name)
		{
			var value = _configuration[$"{_sectionName}:{name}"];

			if (value is null)
			{
				throw new ApplicationException($"Could not find setting '{name}'");
			}

			return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
		}
	}
}
