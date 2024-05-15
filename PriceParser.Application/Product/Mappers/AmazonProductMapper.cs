using Lynkco.Warranty.WebAPI.Application.Common.Mapper;
using Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Models;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;
using System.Globalization;

namespace Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Mappers
{
	public class AmazonProductMapper : MapperBase<AmazonProductModel, ProductEntity>
	{
		public override ProductEntity Map(AmazonProductModel source)
		{
			return new()
			{
				Title = source.Title,
				Description = source.Description,
				Category = source.Category,
				AvgRating = source.AvgRating,
				ReviewCount = source.ReviewCount,
				OutOfStock = source.OutOfStock,
				Currency = "$",
				PriceHistory = new List<PriceHistory>
				{
					new()
					{
						Date = DateTime.UtcNow,
						Price = double.TryParse(source.Price, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"), out var price) ? price : 0,
					},
				},
				ImageUrl = source.Images.FirstOrDefault(),
			};
		}
	}
}
