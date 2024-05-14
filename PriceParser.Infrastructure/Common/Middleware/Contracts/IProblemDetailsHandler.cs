using Hellang.Middleware.ProblemDetails;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Middleware.Contracts
{
	public interface IProblemDetailsHandler
	{
		void HandleOptions(ProblemDetailsOptions problemDetailsOptions);
	}
}
