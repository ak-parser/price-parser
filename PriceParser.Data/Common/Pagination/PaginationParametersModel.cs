using Newtonsoft.Json;
using PriceParser.Domain.Common.Pagination.Contracts;

namespace PriceParser.Data.Common.Pagination
{
	public class PaginationParametersModel : IPaginationParameters
	{
		[JsonProperty("pageNumber")]
		public int PageNumber { get; set; } = 1;

		[JsonProperty("pageSize")]
		public int PageSize { get; set; } = 10;
	}
}
