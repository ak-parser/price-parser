using PriceParser.Infrastructure.Common.Utilities.Contracts;

namespace PriceParser.Infrastructure.Common.Utilities
{
	public class SecondsToMinutesCalculator : ISecondsToMinutesCalculator
	{
		private const int _secondsInMinute = 60;
		private const int _fractionalDigits = 2;
		private const MidpointRounding _rounding = MidpointRounding.AwayFromZero;

		public double Calculate(int seconds)
		{
			if (seconds <= 0)
			{
				return 0;
			}

			return Math.Round((double)seconds / _secondsInMinute, _fractionalDigits, _rounding);
		}
	}
}
