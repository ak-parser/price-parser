using Newtonsoft.Json;

namespace PriceParser.ProcessExternalData.Common.Models
{
	public record DataEventModel<T>
	{
		[JsonProperty("data")]
		public T Data { get; set; }
	}
}
