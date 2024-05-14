namespace Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts
{
	public interface IConfigProvider<TModel>
	{
		public TModel GetData();
	}
}
