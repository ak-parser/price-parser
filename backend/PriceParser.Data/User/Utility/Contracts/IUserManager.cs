using PriceParser.Data.User.Models;

namespace PriceParser.Data.User.Utility.Contracts
{
	public interface IUserManager
	{
		public UserModel GetCurrentUser();
	}
}
