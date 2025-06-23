using Newtonsoft.Json;

namespace PriceParser.Host.Product.Models
{
	public class EmailRequestModel
	{
		[JsonProperty("email")]
		public string Email { get; set; }
	}
}
