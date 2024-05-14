namespace Lynkco.Warranty.WebAPI.Application.Common.AzureEventGrid.Service.Contracts
{
	public interface IEventGridService
	{
		public Task TriggerEvent<TEventType, TEventData>(string topicName, TEventType eventType, TEventData eventData)
			where TEventType : Enum;
		public Task TriggerEvent<TEventType, TEventData>(string topicName, TEventType eventType, TEventData eventData, string dataVersion = "v1")
			where TEventType : Enum;
	}
}
