using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Common.Mapper.Contracts;
using PriceParser.Application.Common.Services.Contracts;
using PriceParser.Application.Product.Mappers;
using PriceParser.Application.Product.Models;
using PriceParser.Application.Product.Service;
using PriceParser.Application.Product.Service.Contracts;
using PriceParser.Domain.Product.Entities;

namespace PriceParser.Application.Product.Config
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
