namespace PriceParser.Application.Common.Exceptions
{
	public class PreConditionValidationException : Exception
	{
		public PreConditionValidationException()
		{
		}

		public PreConditionValidationException(string message)
			: base(message)
		{
		}

		public PreConditionValidationException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
