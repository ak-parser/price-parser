using System.Diagnostics.CodeAnalysis;
using Lynkco.Warranty.WebAPI.Application.Common.Authentication.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Lynkco.Warranty.WebAPI.Application.Common.Authentication.Config
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
