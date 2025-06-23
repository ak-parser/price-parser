using PriceParser.Data.Common.Utilities.Contracts;

namespace PriceParser.Application.Common.Utilities
{
	public class EpochHelper : IEpochHelper
	{
		public long? DateTimeToEpoch(DateTime? date)
		{
			if (!date.HasValue)
			{
				return null;
			}

			return DateTimeToEpoch(date.Value);
		}

		public long DateTimeToEpoch(DateTime date)
		{
			var epoch = new DateTime(1970, 1, 1);
			var epochTimeSpan = date - epoch;
			return (long)epochTimeSpan.TotalMilliseconds;
		}

		public DateTime EpochToDateTime(long epoch) =>
			new DateTime(1970, 1, 1).AddMilliseconds(epoch);

		public DateTime? EpochToDateTime(long? epoch) =>
			epoch.HasValue ? EpochToDateTime(epoch.Value) : null;
	}
}
