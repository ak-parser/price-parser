using Lynkco.Warranty.WebAPI.Domain.Common.Entities;

namespace Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities
{
	public class ProductEntity : BaseEntity
	{
		public string Url { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public double Price { get; set; }
		public string Currency { get; set; }
	}
}
