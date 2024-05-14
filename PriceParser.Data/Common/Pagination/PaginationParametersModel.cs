using Lynkco.Warranty.WebAPI.Domain.Common.Pagination.Contracts;
using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Data.Common.Pagination
{
	public class PaginationParametersModel : IPaginationParameters
	{
		[JsonProperty("pageNumber")]
		public int PageNumber { get; set; } = 1;

		[JsonProperty("pageSize")]
		public int PageSize { get; set; } = 10;
	}
}
