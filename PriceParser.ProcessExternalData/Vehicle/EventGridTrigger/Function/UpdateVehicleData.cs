using Azure.Messaging.EventGrid;
using Lynkco.Warranty.WebAPI.ProcessExternalData.Common.EventGridTrigger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lynkco.Warranty.WebAPI.ProcessExternalData.Vehicle.EventGridTrigger.Function
{
	public class UpdateVehicleData
	{
		[FunctionName("UpdateVehicleDataHttp")]
		public async Task<IActionResult> RunHttp(
			[HttpTrigger("post", Route = null)] HttpRequest req,
			ILogger log,
			CancellationToken ct)
		{
			var requestBody = string.Empty;
			using (var streamReader = new StreamReader(req.Body))
			{
				requestBody = await streamReader.ReadToEndAsync();
			}

			var eventData = JsonConvert.DeserializeObject<EventGridEventHttpModel<string>>(requestBody);
			var data = eventData.Data;

			await Execute(eventData.EventType, data, ct);
			return new OkResult();
		}

		[FunctionName("UpdateVehicleData")]
		public async Task Run([EventGridTrigger] EventGridEvent eventGridEvent,
			ILogger log,
			CancellationToken ct)
		{
			log.LogInformation($"EventType: {eventGridEvent.EventType}");
			log.LogInformation($"Event Data: {eventGridEvent.Data}");

			var data = JsonConvert.DeserializeObject<string>(eventGridEvent.Data.ToString());
			await Execute(eventGridEvent.EventType, data, ct);
		}

		private async Task Execute(string eventType, string model, CancellationToken ct)
		{

		}
	}
}
