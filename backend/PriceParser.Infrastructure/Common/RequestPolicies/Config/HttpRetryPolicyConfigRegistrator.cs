using Microsoft.Extensions.DependencyInjection;
using PriceParser.Data.Common.Const;

namespace PriceParser.Infrastructure.Common.RequestPolicies.Config
{
	public static class HttpRetryPolicyConfigRegistrator
	{
		public static void AddHttpClients(IServiceCollection services)
		{
			services.AddHttpClient(HttpClientNames.RequestRetryPollyImmediate).AddPolicyHandler(
				request => request.Method == HttpMethod.Get || request.Method == HttpMethod.Post
					? new RequestRetryPolicy().ImmediateHttpRetry
					: new RequestRetryPolicy().ImmediateHttpRetry);

			services.AddHttpClient(HttpClientNames.RequestRetryPollyLinear).AddPolicyHandler(
				request => request.Method == HttpMethod.Get || request.Method == HttpMethod.Post
					? new RequestRetryPolicy().LinearHttpRetry
					: new RequestRetryPolicy().LinearHttpRetry);

			services.AddHttpClient(HttpClientNames.RequestRetryPollyExponential).AddPolicyHandler(
				request => request.Method == HttpMethod.Get || request.Method == HttpMethod.Post
					? new RequestRetryPolicy().ExponentialHttpRetry
					: new RequestRetryPolicy().ExponentialHttpRetry);
		}
	}
}
