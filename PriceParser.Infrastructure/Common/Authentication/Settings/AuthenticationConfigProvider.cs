using Lynkco.Warranty.WebAPI.Application.Common.Authentication.Settings.Models;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Config.Settings;
using Microsoft.Extensions.Configuration;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Authentication.Settings
{
	public class AuthenticationConfigProvider : BaseAppSettingsProvider, IConfigProvider<AuthenticationSettings>
	{
		public AuthenticationConfigProvider(IConfiguration configuration)
			: base(configuration, "AzureAd")
		{
		}

		public AuthenticationSettings GetData()
		{
			var instance = Setting<string>($"Instance");
			var tenantId = Setting<string>($"TenantId");
			var clientId = Setting<string>($"ClientId");
			var scope = Setting<string>($"Scope");
			if (string.IsNullOrEmpty(instance) || string.IsNullOrEmpty(tenantId) ||
				string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(scope))
			{
				throw new ArgumentException("Authentication config data is empty!");
			}

			return new AuthenticationSettings(instance, tenantId, clientId, scope);
		}
	}
}
