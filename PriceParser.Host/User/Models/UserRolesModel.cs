using Lynkco.Warranty.WebAPI.Domain.User.Const;
using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Host.User.Models
{
	public class UserRolesModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("roles")]
		public List<UserRole> Roles { get; set; } = new();
	}
}
