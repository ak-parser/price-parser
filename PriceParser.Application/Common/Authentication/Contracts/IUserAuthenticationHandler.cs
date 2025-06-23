using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PriceParser.Application.Common.Authentication.Contracts
{
	public interface IUserAuthenticationHandler
	{
		Task OnTokenValidatedHandler(TokenValidatedContext context);
	}
}
