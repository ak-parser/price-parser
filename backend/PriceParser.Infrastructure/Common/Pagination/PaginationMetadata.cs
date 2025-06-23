using Newtonsoft.Json;

namespace PriceParser.Infrastructure.Common.Pagination
{
	public class PaginationMetadata
	{
		[JsonProperty("totalCount")]
		public int TotalCount { get; set; }

		[JsonProperty("pageSize")]
		public int PageSize { get; set; }

		[JsonProperty("currentPage")]
		public int CurrentPage { get; set; }

		[JsonProperty("totalPages")]
		public int TotalPages { get; set; }

		[JsonProperty("hasNext")]
		public bool HasNext { get; set; }

		[JsonProperty("hasPrevious")]
		public bool HasPrevious { get; set; }
	}
}
