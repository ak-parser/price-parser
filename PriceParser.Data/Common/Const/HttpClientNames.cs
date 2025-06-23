namespace PriceParser.Data.Common.Const
{
	public static class HttpClientNames
	{
		public const string RequestRetryPollyImmediate = "PollyWaitAndRetryImmediatly";
		public const string RequestRetryPollyLinear = "PollyWaitAndRetryLinear";
		public const string RequestRetryPollyExponential = "PollyWaitAndRetryExponential";
	}
}
