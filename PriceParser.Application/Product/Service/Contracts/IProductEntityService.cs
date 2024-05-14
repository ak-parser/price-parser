using Lynkco.Warranty.WebAPI.Application.Common.Services.Contracts;
using Lynkco.Warranty.WebAPI.Domain.VehicleWarranty.Entities;

namespace Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Service.Contracts
{
	public interface IProductEntityService : IBaseInternalEntityService<ProductEntity>
	{
		public Task<ProductEntity> UpdateAsync(ProductEntity vehicle, bool triggerUpdateEvent, CancellationToken ct);

		public Task<ProductEntity> FetchProduct(string url, CancellationToken ct);
	}
}
