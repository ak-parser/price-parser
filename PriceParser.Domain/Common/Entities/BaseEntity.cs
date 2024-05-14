using Lynkco.Warranty.WebAPI.Domain.Common.Entities.Contracts;
using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Domain.Common.Entities
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
