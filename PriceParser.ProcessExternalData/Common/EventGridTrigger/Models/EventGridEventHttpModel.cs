using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.ProcessExternalData.Common.EventGridTrigger.Models
{
	public class EventGridEventHttpModel<TData>
	{
		[JsonProperty("eventType")]
		public string EventType { get; set; }

		[JsonProperty("data")]
		public TData Data { get; set; }
	}
}
