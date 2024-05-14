using System.Security.Claims;
using Lynkco.Warranty.WebAPI.Application.Common.Authentication.Contracts;
using Lynkco.Warranty.WebAPI.Application.Common.Authentication.Settings.Models;
using Lynkco.Warranty.WebAPI.Application.Comparers.Contracts;
using Lynkco.Warranty.WebAPI.Application.User.Service.Contracts;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.User.Entity;
using Lynkco.Warranty.WebAPI.Domain.User.Repository.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Lynkco.Warranty.WebAPI.Application.Common.Authentication
{
	public class UserAuthenticationHandler : IUserAuthenticationHandler
	{
		private const string ObjectClaimType = "http://schemas.microsoft.com/identity/claims/objectidentifier";
		private const string ScopeClaimType = "http://schemas.microsoft.com/identity/claims/scope";

		private readonly IUserRepository _userRepository;
		private readonly IEqualityChecker<UserEntity> _comparer;
		private readonly IConfigProvider<AuthenticationSettings> _authSettings;
		private readonly IEpochHelper _epochHelper;
		private readonly IUserManagementEntityService _userManagementService;

		public UserAuthenticationHandler(
			IUserRepository userRepository,
			IEqualityChecker<UserEntity> comparer,
			IConfigProvider<AuthenticationSettings> authSettings,
			IEpochHelper epochHelper,
			IUserManagementEntityService userManagementService)
		{
			_userRepository = userRepository;
			_comparer = comparer;
			_authSettings = authSettings;
			_epochHelper = epochHelper;
			_userManagementService = userManagementService;
		}

		public async Task OnTokenValidatedHandler(TokenValidatedContext context)
		{
			using (var cancelTokenSource = new CancellationTokenSource())
			{
				var ct = cancelTokenSource.Token;
				var objectId = context.Principal.FindFirstValue(ObjectClaimType);

				var scope = context.Principal.FindFirstValue(ScopeClaimType);
				if (scope != _authSettings.GetData().Scope)
				{
					context.Fail("No required scopes provided");
					return;
				}

				var contextUser = new UserEntity()
				{
					Id = objectId,
					Email = context.Principal.FindFirstValue("preferred_username"),
					UserName = context.Principal.FindFirstValue("name"),
					CreationTime = _epochHelper.DateTimeToEpoch(DateTime.Now.ToUniversalTime()),
					LastActiveTime = _epochHelper.DateTimeToEpoch(DateTime.Now.ToUniversalTime())
				};
				var dbUser = await _userRepository.GetByIdAsync(objectId, ct);

				if (dbUser == null)
				{
					await _userManagementService.CreateUserAsync(contextUser, ct);
				}
				else
				{
					contextUser.Roles = dbUser.Roles;
					contextUser.CreationTime = dbUser.CreationTime;
					contextUser.Customizations = dbUser.Customizations;
					if (!_comparer.Equals(contextUser, dbUser))
					{
						await _userRepository.UpdateAsync(contextUser, ct);
					}
				}

				var userIdentity = new ClaimsIdentity(contextUser.Roles.Select(role => new Claim(ClaimTypes.Role, role.ToString())));
				userIdentity.AddClaim(new Claim(ClaimTypes.Name, contextUser.UserName));
				userIdentity.AddClaim(new Claim(ObjectClaimType, objectId));
				context.Principal.AddIdentity(userIdentity);
			}
		}
	}
}
