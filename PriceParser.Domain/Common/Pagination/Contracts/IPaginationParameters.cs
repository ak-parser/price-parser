namespace Lynkco.Warranty.WebAPI.Domain.Common.Pagination.Contracts
{
	public interface IPaginationParameters
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
