using Newtonsoft.Json;
using PriceParser.Domain.User.Const;

namespace PriceParser.Host.User.Models
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
