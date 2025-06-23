using PriceParser.Application.Comparers.Contracts;
using PriceParser.Domain.User.Entity;

namespace PriceParser.Application.Comparers
{
	public class UserEqualityComparer : IEqualityChecker<UserEntity>
	{
		public bool Equals(UserEntity x, UserEntity y)
		{
			if (x != null && y != null &&
				x.Id == y.Id &&
				x.Email == y.Email &&
				x.UserName == y.UserName &&
				x.CreationTime == y.CreationTime &&
				x.LastActiveTime == y.LastActiveTime &&
				x.Roles.SequenceEqual(y.Roles))
			{
				return true;
			}

			return false;
		}
	}
}
