using PriceParser.Application.Common.Mapper;
using PriceParser.Application.Common.Utilities.Contracts;
using PriceParser.Data.Common.Utilities.Contracts;
using PriceParser.Domain.Product.Entities;
using PriceParser.Host.Product.Models;

namespace PriceParser.Host.Product.Mapper
{
	public class ProductModelMapper : MapperBase<ProductEntity, ProductModel>
	{
		private readonly ITimezoneOffsetProvider _timezoneOffsetProvider;
		private readonly IEpochHelper _epochHelper;

		public ProductModelMapper(
			ITimezoneOffsetProvider timezoneOffsetProvider,
			IEpochHelper epochHelper)
		{
			_timezoneOffsetProvider = timezoneOffsetProvider;
			_epochHelper = epochHelper;
		}

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
