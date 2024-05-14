using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Lynkco.Warranty.WebAPI.Application.Common.Authentication.Contracts
{
	public interface IUserAuthenticationHandler
	{
		Task OnTokenValidatedHandler(TokenValidatedContext context);
	}
}
