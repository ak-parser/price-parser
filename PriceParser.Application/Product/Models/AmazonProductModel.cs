using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Models
{
	public class AmazonProductModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }
		public List<string> Images { get; set; }
	}
}
