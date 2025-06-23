using PriceParser.Data.Common.Utilities.Contracts;

namespace PriceParser.Application.Common.Utilities
{
	public class DateHelper : IDateHelper
	{
		public DateOnly DateTimeToDateOnly(DateTime date)
			=> DateOnly.FromDateTime(date);

		public DateOnly? DateTimeToDateOnly(DateTime? date)
			=> date.HasValue ? DateTimeToDateOnly(date.Value) : null;
	}
}
