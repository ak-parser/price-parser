using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;

namespace Lynkco.Warranty.WebAPI.Application.Common.Utilities
{
	public class DateHelper : IDateHelper
	{
		public DateOnly DateTimeToDateOnly(DateTime date)
			=> DateOnly.FromDateTime(date);

		public DateOnly? DateTimeToDateOnly(DateTime? date)
			=> date.HasValue ? DateTimeToDateOnly(date.Value) : null;
	}
}
