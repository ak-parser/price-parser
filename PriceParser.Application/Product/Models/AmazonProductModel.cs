using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Models
{
	public class AmazonProductModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }

		public string Category { get; set; }
		public List<string> Images { get; set; }

		[JsonProperty("price_without_discount")]
		public string PriceWithoutDiscount { get; set; }

		[JsonProperty("avg_rating")]
		public string AvgRating { get; set; }

		[JsonProperty("review_count")]
		public string ReviewCount { get; set; }

		[JsonProperty("out_of_stock")]
		public bool OutOfStock { get; set; }
	}
}
