using Hellang.Middleware.ProblemDetails;

namespace PriceParser.Infrastructure.Common.Middleware.Contracts
{
	public interface IProblemDetailsHandler
	{
		void HandleOptions(ProblemDetailsOptions problemDetailsOptions);
	}
}
