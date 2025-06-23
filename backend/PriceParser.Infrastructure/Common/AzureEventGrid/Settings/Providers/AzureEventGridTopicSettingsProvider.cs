using Microsoft.Extensions.Configuration;
using PriceParser.Infrastructure.Common.AzureEventGrid.Settings.Models;
using PriceParser.Infrastructure.Common.AzureEventGrid.Settings.Providers.Contracts;
using PriceParser.Infrastructure.Common.Config.Settings;

namespace PriceParser.Infrastructure.Common.AzureEventGrid.Settings.Providers
{
	public class AzureEventGridTopicSettingsProvider : BaseAppSettingsProvider,
		IEventGridTopicSettingsProvider
	{
		public AzureEventGridTopicSettingsProvider(IConfiguration configuration)
			: base(configuration, "EventGrid")
		{
		}

		public AzureEventGridTopicSettings GetTopicSettings(string topicName)
		{
			var url = Setting<string>($"Topics:{topicName}:Endpoint");
			var accessKey = Setting<string>($"Topics:{topicName}:AccessKey");
			if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(accessKey))
			{
				throw new ArgumentException("AzureEventGrid Topic config settings are empty");
			}

			return new AzureEventGridTopicSettings(new Uri(url), accessKey);
		}
	}
}
