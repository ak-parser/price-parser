namespace PriceParser.Application.Comparers.Contracts
{
	public interface IEqualityChecker<T>
	{
		bool Equals(T x, T y);
	}
}
