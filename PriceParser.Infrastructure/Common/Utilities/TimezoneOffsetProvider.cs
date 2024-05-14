using Lynkco.Warranty.WebAPI.Application.Common.Utilities.Contracts;
using Microsoft.AspNetCore.Http;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Utilities
{
	public class TimezoneOffsetProvider : ITimezoneOffsetProvider
	{
		protected const string TimezoneHeader = "X-Time-Zone";
		private readonly IHttpContextAccessor _httpContextAccessor;

		public TimezoneOffsetProvider(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public DateTime? OffsetToLocalTime(DateTime? date)
		{
			if (date.HasValue)
			{
				return OffsetToLocalTime(date.Value);
			}

			return null;
		}

		public DateTime OffsetToLocalTime(DateTime date)
			=> new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Unspecified)
				.AddMinutes(Convert.ToInt32(_httpContextAccessor.HttpContext?.Request?.Headers[TimezoneHeader]) * -1);

		public DateTime? LocalTimeToUniversalTime(DateTime? date)
		{
			if (date.HasValue)
			{
				return LocalTimeToUniversalTime(date.Value);
			}

			return null;
		}

		public DateTime LocalTimeToUniversalTime(DateTime date)
			=> new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Unspecified)
				.AddMinutes(Convert.ToInt32(_httpContextAccessor.HttpContext?.Request?.Headers[TimezoneHeader]));
	}
}