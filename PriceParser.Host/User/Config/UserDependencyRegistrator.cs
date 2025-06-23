using System.Diagnostics.CodeAnalysis;
using PriceParser.Application.Common.Mapper.Contracts;
using PriceParser.Domain.User.Entity;
using PriceParser.Host.User.Mapper;
using PriceParser.Host.User.Models;

namespace PriceParser.Host.User.Config
{
	[ExcludeFromCodeCoverage]
	public static class UserDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddTransient<IMapper<UserEntity, UserModel>, UserModelMapper>();
		}
	}
}
