using Lynkco.Warranty.WebAPI.Data.VehicleWarranty.Repository;
using Lynkco.Warranty.WebAPI.Domain.Common.Repositories;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Data.VehicleWarranty.Config
{
	[ExcludeFromCodeCoverage]
	public static class ProductDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddScoped<IProductRepository, CosmosDbProductRepository>();
			services.AddScoped<IBaseRepository<ProductEntity>, CosmosDbProductRepository>();
			services.AddScoped<CosmosDbProductRepository>();
		}
	}
}
