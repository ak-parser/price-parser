using Lynkco.Warranty.WebAPI.Data.User.Repository;
using Lynkco.Warranty.WebAPI.Domain.Common.Repositories;
using Lynkco.Warranty.WebAPI.Domain.User.Entity;
using Lynkco.Warranty.WebAPI.Domain.User.Repository.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Data.User.Config
{
	[ExcludeFromCodeCoverage]
	public static class UserDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository, CosmosDbUserRepository>();
			services.AddScoped<IBaseRepository<UserEntity>, CosmosDbUserRepository>();
		}
	}
}
