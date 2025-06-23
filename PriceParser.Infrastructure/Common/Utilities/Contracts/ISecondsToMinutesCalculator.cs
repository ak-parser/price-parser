namespace PriceParser.Infrastructure.Common.Utilities.Contracts
{
	public interface ISecondsToMinutesCalculator
	{
		public double Calculate(int seconds);
	}
}
