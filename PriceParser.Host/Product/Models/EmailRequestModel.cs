using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Host.VehicleWarranty.Models
{
	public class EmailRequestModel
	{
		[JsonProperty("email")]
		public string Email { get; set; }
	}
}
