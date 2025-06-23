using Lynkco.Warranty.WebAPI.Domain.Common.Attributes;

namespace PriceParser.Domain.User.Const
{
	public enum UserRole
	{
		[EnumMemberText("User")]
		User = 0,

		[EnumMemberText("Admin")]
		Admin = 1,
	}

	public static class UserRoles
	{
		public const string User = "User";
		public const string Admin = "Admin";
	}
}
