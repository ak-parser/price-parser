using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Models
{
	public class ProductModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
