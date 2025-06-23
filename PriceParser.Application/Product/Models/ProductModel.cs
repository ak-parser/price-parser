using Newtonsoft.Json;

namespace PriceParser.Application.Product.Models
{
	public class ProductModel
	{
		[JsonProperty("vin")]
		public string Vin { get; set; }
	}
}
