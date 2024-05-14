namespace Lynkco.Warranty.WebAPI.Domain.Common.Utility
{
	public static class DateTimeHelper
	{
		public static DateTime? TryParseToDateNullable(string text)
			=> DateTime.TryParse(text, out var date) ? date : null;
	}
}
