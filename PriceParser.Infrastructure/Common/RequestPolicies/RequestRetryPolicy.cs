using System.Net;
using System.Net.Sockets;
using Polly;
using Polly.Retry;

namespace PriceParser.Infrastructure.Common.RequestPolicies
{
	public class RequestRetryPolicy
	{
		private const int RetryCount = 7;
		private const int RetryPause = 2;
		private readonly List<HttpStatusCode> _retryCodes = new List<HttpStatusCode>()
		{
			HttpStatusCode.RequestTimeout,
			HttpStatusCode.BadGateway,
			HttpStatusCode.ServiceUnavailable,
			HttpStatusCode.GatewayTimeout
		};

		public RequestRetryPolicy()
		{
			ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
				res => _retryCodes.Contains(res.StatusCode))
				.OrInner<SocketException>()
				.RetryAsync(RetryCount);

			LinearHttpRetry = Policy.HandleResult<HttpResponseMessage>(
				res => _retryCodes.Contains(res.StatusCode))
				.OrInner<SocketException>()
				.WaitAndRetryAsync(RetryCount, retryAttempt => TimeSpan.FromSeconds(RetryPause));

			ExponentialHttpRetry = Policy.HandleResult<HttpResponseMessage>(
				res => _retryCodes.Contains(res.StatusCode))
				.OrInner<SocketException>()
				.WaitAndRetryAsync(RetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(RetryPause, retryAttempt)));
		}

		public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; }
		public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; }
		public AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpRetry { get; }
	}
}
