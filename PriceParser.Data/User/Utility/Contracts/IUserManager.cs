using Lynkco.Warranty.WebAPI.Data.User.Models;

namespace Lynkco.Warranty.WebAPI.Data.User.Utility.Contracts
{
	public interface IUserManager
	{
		public UserModel GetCurrentUser();
	}
}
