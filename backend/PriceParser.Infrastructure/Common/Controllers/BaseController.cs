using Microsoft.AspNetCore.Mvc;
using PriceParser.Domain.Common.Pagination.Contracts;
using PriceParser.Infrastructure.Common.Pagination;

namespace PriceParser.Infrastructure.Common.Controllers
{
	[ApiController]
	public abstract class BaseController : ControllerBase
	{
		protected ActionResult<IEnumerable<T>> OkPaged<T>(
			IEnumerable<T> items,
			IPaginationParameters pagination,
			int itemsCount)
		{
			var pagedList = new PagedList<T>(
				items,
				itemsCount,
				pagination.PageNumber,
				pagination.PageSize);

			Response?.Headers.Add("X-Pagination", pagedList.CreateMetadata());
			Response?.Headers.Add("Access-Control-Expose-Headers", "Content-Encoding, X-Pagination");

			return Ok(pagedList);
		}
	}
}
