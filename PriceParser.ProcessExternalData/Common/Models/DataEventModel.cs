using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.ProcessExternalData.Common.Models
{
	public record DataEventModel<T>
	{
		[JsonProperty("data")]
		public T Data { get; set; }
	}
}
