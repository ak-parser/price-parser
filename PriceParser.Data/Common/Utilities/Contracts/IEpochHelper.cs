namespace Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts
{
	public interface IEpochHelper
	{
		public long DateTimeToEpoch(DateTime date);
		public long? DateTimeToEpoch(DateTime? date);

		public DateTime? EpochToDateTime(long? epoch);
		public DateTime EpochToDateTime(long epoch);
	}
}
