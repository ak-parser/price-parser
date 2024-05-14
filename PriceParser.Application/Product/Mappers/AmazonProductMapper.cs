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
				Id = Guid.NewGuid().ToString(),
				Name = source.Title,
				Description = source.Description,
				Price = double.TryParse(source.Price, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"), out var price) ? price : 0,
				Currency = "$",
				ImageUrl = source.Images.FirstOrDefault(),
			};
		}
	}
}
