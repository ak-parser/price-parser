namespace Lynkco.Warranty.WebAPI.Application.Common.Utilities.Contracts
{
	public interface ISalesUpdateHandler<TEntity>
	{
		public Task Update(TEntity entity, CancellationToken ct);
	}
}
