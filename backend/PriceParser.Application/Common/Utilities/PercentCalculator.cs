namespace PriceParser.Application.Common.Utilities
{
	public class PercentCalculator
	{
		public decimal Calculate(int itemCount, int totalCount)
		{
			if (totalCount < itemCount || totalCount == 0)
			{
				throw new ArgumentException("Percent calculator error");
			}

			return (decimal)((double)(100 * itemCount) / totalCount);
		}
	}
}
