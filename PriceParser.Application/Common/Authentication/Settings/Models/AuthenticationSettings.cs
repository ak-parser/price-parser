namespace Lynkco.Warranty.WebAPI.Application.Common.Authentication.Settings.Models
{
	public class AuthenticationSettings
	{
		public AuthenticationSettings(string instance, string tenantId, string clientId, string scope)
		{
			Instance = instance;
			TenantId = tenantId;
			ClientId = clientId;
			Scope = scope;
		}

		public string Instance { get; }
		public string TenantId { get; }
		public string ClientId { get; }
		public string Scope { get; }
	}
}
