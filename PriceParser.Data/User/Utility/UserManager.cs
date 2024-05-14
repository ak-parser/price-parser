using System.Security.Claims;
using Lynkco.Warranty.WebAPI.Data.Common.Const;
using Lynkco.Warranty.WebAPI.Data.User.Models;
using Lynkco.Warranty.WebAPI.Data.User.Utility.Contracts;
using Lynkco.Warranty.WebAPI.Domain.User.Const;
using Microsoft.AspNetCore.Http;

namespace Lynkco.Warranty.WebAPI.Data.User.Utility
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
