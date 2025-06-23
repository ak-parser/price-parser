using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Common.Authentication;
using PriceParser.Application.Common.Authentication.Contracts;

namespace PriceParser.Application.Common.Authentication.Config
{
	[ExcludeFromCodeCoverage]
	public static class AuthenticationDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddTransient<IUserAuthenticationHandler, UserAuthenticationHandler>();
		}
	}
}
