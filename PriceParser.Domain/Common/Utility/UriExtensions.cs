using System.Web;

namespace PriceParser.Domain.Common.Utility
{
	public static class UriExtensions
	{
		/// <summary>
		/// Adds the specified parameter to the URL query.
		/// </summary>
		/// <param name="url">URL to add parameter to.</param>
		/// <param name="paramName">Name of the parameter to add.</param>
		/// <param name="paramValue">Value for the parameter to add.</param>
		/// <param name="empty">Process null or empty params</param>
		/// <returns>URL with added parameter.</returns>
		public static Uri AddQueryParameter(Uri url, string paramName, string paramValue, bool empty = false)
		{
			if (!empty && (string.IsNullOrEmpty(paramName) || string.IsNullOrEmpty(paramValue)))
			{
				return url;
			}

			var uriBuilder = new UriBuilder(url);
			var query = HttpUtility.ParseQueryString(uriBuilder.Query);
			query[paramName] = paramValue;
			uriBuilder.Query = query.ToString();

			return uriBuilder.Uri;
		}
	}
}
