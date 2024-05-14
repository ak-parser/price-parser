namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.AzureEventGrid.Settings.Models
{
	public class AzureEventGridTopicSettings
	{
		public AzureEventGridTopicSettings(Uri eventUri, string accessKey)
		{
			EventUri = eventUri;
			AccessKey = accessKey;
		}

		public Uri EventUri { get; }
		public string AccessKey { get; }
	}
}
