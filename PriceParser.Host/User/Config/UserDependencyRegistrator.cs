using System.Diagnostics.CodeAnalysis;
using Lynkco.Warranty.WebAPI.Application.Common.Mapper.Contracts;
using Lynkco.Warranty.WebAPI.Domain.User.Entity;
using Lynkco.Warranty.WebAPI.Host.User.Mapper;
using Lynkco.Warranty.WebAPI.Host.User.Models;

namespace Lynkco.Warranty.WebAPI.Host.User.Config
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
