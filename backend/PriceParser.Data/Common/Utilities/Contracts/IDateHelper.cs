﻿namespace PriceParser.Data.Common.Utilities.Contracts
{
	public interface IDateHelper
	{
		public DateOnly DateTimeToDateOnly(DateTime date);
		public DateOnly? DateTimeToDateOnly(DateTime? date);
	}
}
