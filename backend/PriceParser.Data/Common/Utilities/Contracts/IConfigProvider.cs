namespace PriceParser.Data.Common.Utilities.Contracts
{
	public interface IConfigProvider<TModel>
	{
		public TModel GetData();
	}
}
