using Newtonsoft.Json;

namespace PriceParser.Host.Product.Models
{
	public class ScrapRequestModel
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
