using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PriceParser.Data.Common.Const;
using PriceParser.Data.User.Models;
using PriceParser.Data.User.Utility.Contracts;
using PriceParser.Domain.User.Const;

namespace PriceParser.Data.User.Utility
{
	public class UserManager : IUserManager
	{
		private const string ObjectClaimType = "http://schemas.microsoft.com/identity/claims/objectidentifier";
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserManager(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public UserModel GetCurrentUser()
		{
			var userRoles = Enum.GetValues<UserRole>();
			return new()
			{
				UserId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ObjectClaimType) ?? SystemNames.SystemId,
				Username = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ?? SystemNames.SystemName,
				UserRoles = _httpContextAccessor.HttpContext?.User?.Claims
							.Where(x => x.Type == ClaimTypes.Role)
							.Select(r => userRoles.FirstOrDefault(ur => ur.ToString() == r.Value))
							.ToList()
			};
		}
	}
}
