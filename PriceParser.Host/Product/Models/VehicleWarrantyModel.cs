using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Models
{
	public class VehicleWarrantyModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
