using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Messaging.EventGrid;
using Lynkco.Warranty.WebAPI.Application.Common.AzureEventGrid.Service.Contracts;
using Lynkco.Warranty.WebAPI.Domain.Common.Utility;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Settings.Providers.Contracts;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Service
{
	[ExcludeFromCodeCoverage]
	public class AzureEventGridService : IEventGridService
	{
		private readonly IEventGridTopicSettingsProvider _settingsProvider;

		public AzureEventGridService(IEventGridTopicSettingsProvider settingsProvider)
		{
			_settingsProvider = settingsProvider;
		}

		public async Task TriggerEvent<TEventType, TEventData>(string topicName, TEventType eventType, TEventData eventData) where TEventType : Enum
		{
			await TriggerEvent(topicName, eventType, eventData, "v1");
		}

		public async Task TriggerEvent<TEventType, TEventData>(
			string topicName,
			TEventType eventType,
			TEventData eventData,
			string dataVersion) where TEventType : Enum
		{
			var settings = _settingsProvider.GetTopicSettings(topicName);
			if (settings is null)
			{
				return;
			}

			var eventTypeString = eventType.GetEnumMemberValue();
			var client = new EventGridPublisherClient(
				settings.EventUri,
				new AzureKeyCredential(settings.AccessKey));

			var gridEvent = new EventGridEvent(
				eventTypeString,
				eventTypeString,
				dataVersion,
				eventData);

			await client.SendEventAsync(gridEvent);
		}
	}
}
