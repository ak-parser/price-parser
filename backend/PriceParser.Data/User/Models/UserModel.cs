using PriceParser.Domain.User.Const;

namespace PriceParser.Data.User.Models
{
	public class UserModel
	{
		public string Username { get; set; }
		public string UserId { get; set; }
		public List<UserRole> UserRoles { get; set; }
	}
}
