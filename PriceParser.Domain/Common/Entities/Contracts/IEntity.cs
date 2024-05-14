namespace Lynkco.Warranty.WebAPI.Domain.Common.Entities.Contracts
{
	public interface IEntity
	{
		public string Id { get; set; }
		public string ETag { get; set; }
	}
}
