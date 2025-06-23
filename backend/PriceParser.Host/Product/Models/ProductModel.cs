using Newtonsoft.Json;

namespace PriceParser.Host.Product.Models
{
	public class ProductModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
