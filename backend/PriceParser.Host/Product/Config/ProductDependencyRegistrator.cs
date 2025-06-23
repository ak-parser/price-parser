using System.Diagnostics.CodeAnalysis;
using PriceParser.Application.Common.Mapper.Contracts;
using PriceParser.Domain.Product.Entities;
using PriceParser.Host.Product.Mapper;
using PriceParser.Host.Product.Models;

namespace PriceParser.Host.Product.Config
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
