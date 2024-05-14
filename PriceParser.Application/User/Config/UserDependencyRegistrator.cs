using System.Diagnostics.CodeAnalysis;
using Lynkco.Warranty.WebAPI.Application.Common.Services.Contracts;
using Lynkco.Warranty.WebAPI.Application.Comparers;
using Lynkco.Warranty.WebAPI.Application.Comparers.Contracts;
using Lynkco.Warranty.WebAPI.Application.User.Service;
using Lynkco.Warranty.WebAPI.Application.User.Service.Contracts;
using Lynkco.Warranty.WebAPI.Data.User.Utility;
using Lynkco.Warranty.WebAPI.Data.User.Utility.Contracts;
using Lynkco.Warranty.WebAPI.Domain.User.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Lynkco.Warranty.WebAPI.Application.User.Config
{
	[ExcludeFromCodeCoverage]
	public static class UserDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddTransient<IBaseInternalEntityService<UserEntity>, UserManagementEntityService>();
			services.AddTransient<IUserManagementEntityService, UserManagementEntityService>();

			services.AddTransient<IEqualityChecker<UserEntity>, UserEqualityComparer>();

			services.AddTransient<IUserManager, UserManager>();
		}
	}
}
