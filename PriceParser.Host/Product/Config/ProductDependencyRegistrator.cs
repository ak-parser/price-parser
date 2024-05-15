using Lynkco.Warranty.WebAPI.Application.Common.Mapper.Contracts;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Mapper;
using Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Models;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Config
{
	[ExcludeFromCodeCoverage]
	public static class ProductDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddTransient<IMapper<ProductEntity, ProductModel>, ProductModelMapper>();
		}
	}
}
