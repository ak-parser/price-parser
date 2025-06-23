using PriceParser.Infrastructure.Common.AzureEventGrid.Settings.Models;

namespace PriceParser.Infrastructure.Common.AzureEventGrid.Settings.Providers.Contracts
{
	public interface IEventGridTopicSettingsProvider
	{
		public AzureEventGridTopicSettings GetTopicSettings(string topicName);
	}
}
