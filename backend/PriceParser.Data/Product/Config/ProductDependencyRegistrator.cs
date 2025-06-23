using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Data.Product.Repository;
using PriceParser.Domain.Common.Repositories;
using PriceParser.Domain.Product.Entities;
using PriceParser.Domain.Product.Repositories.Contracts;

namespace PriceParser.Data.Product.Config
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
