using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Models
{
	public class ScrapRequestModel
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
