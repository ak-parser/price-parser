namespace PriceParser.Data.Common.Utilities.Contracts
{
	public interface IKeyGenerator
	{
		public Task<string> GenerateKey(string destination, string prefix, CancellationToken ct);
	}
}
