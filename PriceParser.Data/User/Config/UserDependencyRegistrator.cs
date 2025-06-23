using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Data.User.Repository;
using PriceParser.Domain.Common.Repositories;
using PriceParser.Domain.User.Entity;
using PriceParser.Domain.User.Repository.Contracts;

namespace PriceParser.Data.User.Config
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
