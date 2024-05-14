namespace Lynkco.Warranty.WebAPI.Application.Common.Exceptions
{
	public class ETagValidationException : Exception
	{
		public ETagValidationException()
		{
		}

		public ETagValidationException(string message)
			: base(message)
		{
		}

		public ETagValidationException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
