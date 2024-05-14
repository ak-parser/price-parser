using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Models
{
	public class ProductModel
	{
		[JsonProperty("vin")]
		public string Vin { get; set; }
	}
}
