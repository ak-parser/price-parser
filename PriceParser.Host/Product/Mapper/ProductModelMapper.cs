using Lynkco.Warranty.WebAPI.Application.Common.Mapper;
using Lynkco.Warranty.WebAPI.Application.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Models;

namespace Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Mapper
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
