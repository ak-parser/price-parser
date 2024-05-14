using Lynkco.Warranty.WebAPI.Domain.User.Const;
using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Host.User.Models
{
	public class UserPublicModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("username")]
		public string UserName { get; set; }

		[JsonProperty("roles")]
		public List<UserRole> Roles { get; set; } = new();
	}
}
