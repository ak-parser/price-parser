using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Common.Services.Contracts;
using PriceParser.Application.Comparers;
using PriceParser.Application.Comparers.Contracts;
using PriceParser.Application.User.Service;
using PriceParser.Application.User.Service.Contracts;
using PriceParser.Data.User.Utility;
using PriceParser.Data.User.Utility.Contracts;
using PriceParser.Domain.User.Entity;

namespace PriceParser.Application.User.Config
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
