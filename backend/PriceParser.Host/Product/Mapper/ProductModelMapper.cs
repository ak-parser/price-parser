using PriceParser.Application.Common.Mapper;
using PriceParser.Domain.Product.Entities;
using PriceParser.Host.Product.Models;

namespace PriceParser.Host.Product.Mapper
{
	public class ProductModelMapper : MapperBase<ProductEntity, ProductModel>
	{
		public override ProductModel Map(ProductEntity source)
		{
			var result = new ProductModel()
			{
				Id = source.Id,
			};

			return result;
		}
	}
}
