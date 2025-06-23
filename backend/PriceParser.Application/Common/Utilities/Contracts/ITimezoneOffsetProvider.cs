namespace PriceParser.Application.Common.Utilities.Contracts
{
	public interface ITimezoneOffsetProvider
	{
		public DateTime? OffsetToLocalTime(DateTime? date);
		public DateTime OffsetToLocalTime(DateTime date);

		public DateTime? LocalTimeToUniversalTime(DateTime? date);
		public DateTime LocalTimeToUniversalTime(DateTime date);
	}
}
