using Newtonsoft.Json;
using PriceParser.Domain.Common.Entities.Contracts;

namespace PriceParser.Domain.Common.Entities
{
	public class BaseEntity : IEntity
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("_etag")]
		public string ETag { get; set; }

		[JsonProperty("_ts")]
		public long Timestamp { get; set; }
	}
}
