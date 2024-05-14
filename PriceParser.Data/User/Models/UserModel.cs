using Lynkco.Warranty.WebAPI.Domain.User.Const;

namespace Lynkco.Warranty.WebAPI.Data.User.Models
{
	public class UserModel
	{
		public string Username { get; set; }
		public string UserId { get; set; }
		public List<UserRole> UserRoles { get; set; }
	}
}
