using Lynkco.Warranty.WebAPI.Application.Common.Mapper.Contracts;
using Lynkco.Warranty.WebAPI.Application.Common.Services.Contracts;
using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Mappers;
using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Models;
using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Service;
using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Service.Contracts;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Config
{
	[ExcludeFromCodeCoverage]
	public static class ProductDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddTransient<IBaseInternalEntityService<ProductEntity>, ProductEntityService>();
			services.AddTransient<IProductEntityService, ProductEntityService>();

			// Mappers
			services.AddTransient<IMapper<AmazonProductModel, ProductEntity>, AmazonProductMapper>();
		}
	}
}
