namespace PriceParser.Data.Common.Utilities.Contracts
{
	public interface ICosmosDbSettings
	{
		public string DatabaseId { get; }
		public string ConnectionString { get; }
		public TimeSpan RequestTimeout { get; }
		public int MaxRetryAttemptsOnRateLimitedRequests { get; }
		public TimeSpan MaxRetryWaitTimeOnRateLimitedRequests { get; }
	}
}
