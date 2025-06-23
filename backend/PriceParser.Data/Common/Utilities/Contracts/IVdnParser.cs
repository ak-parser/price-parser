namespace PriceParser.Data.Common.Utilities.Contracts
{
	public interface IVdnParser
	{
		public List<List<string>> Parse(List<string> data);
	}
}
