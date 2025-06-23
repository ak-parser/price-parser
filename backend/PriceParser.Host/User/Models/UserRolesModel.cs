using Newtonsoft.Json;
using PriceParser.Domain.User.Const;

namespace PriceParser.Host.User.Models
{
	public class UserRolesModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("roles")]
		public List<UserRole> Roles { get; set; } = new();
	}
}
