namespace PriceParser.Application.Common.Utilities.Contracts
{
	public interface IHttpResponseTimeWarning
	{
		public TimeSpan WarningThreshold { get; set; }
	}
}
