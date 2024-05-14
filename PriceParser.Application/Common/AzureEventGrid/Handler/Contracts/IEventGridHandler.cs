namespace Lynkco.Warranty.WebAPI.Application.Common.AzureEventGrid.Handler.Contracts
{
	public interface IEventGridHandler<TModel>
	{
		public Task ProcessMessage(TModel model, CancellationToken ct);
	}
}
