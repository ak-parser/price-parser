using Lynkco.Warranty.WebAPI.Domain.Common.Entities;

namespace Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities
{
	public class ProductEntity : BaseEntity
	{
		public string Url { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public string AvgRating { get; set; }
		public string ReviewCount { get; set; }
		public bool OutOfStock { get; set; }
		public string Currency { get; set; }
		public string ImageUrl { get; set; }
		public List<PriceHistory> PriceHistory { get; set; } = new List<PriceHistory>();

		public string UserEmail { get; set; }
	}
}
