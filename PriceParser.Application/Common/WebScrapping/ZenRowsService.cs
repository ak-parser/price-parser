using RestSharp;

public class ZenRowsService : IZenRowsService
{
	private readonly string _apiKey;

	public ZenRowsService(string apiKey)
	{
		_apiKey = apiKey;
	}

	public async Task<string> ScrapeAsync(string url)
	{
		var client = new RestClient("https://api.zenrows.com/v1/?autoparse=true");
		var request = new RestRequest();
		request.AddQueryParameter("url", url);
		request.AddQueryParameter("apikey", _apiKey);

		var response = await client.ExecuteAsync(request);
		if (response.IsSuccessful)
		{
			return response.Content;
		}
		else
		{
			throw new Exception($"Failed to scrape: {response.ErrorMessage}");
		}
	}
}
