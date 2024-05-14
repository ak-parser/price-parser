using Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Settings.Models;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Settings.Providers.Contracts
{
	public interface IEventGridTopicSettingsProvider
	{
		public AzureEventGridTopicSettings GetTopicSettings(string topicName);
	}
}
