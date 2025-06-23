using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using NPOI.OpenXml4Net.Exceptions;
using PriceParser.Application.Common.Exceptions;
using PriceParser.Data.Common.Exceptions;
using PriceParser.Infrastructure.Common.Middleware.Contracts;

namespace PriceParser.Infrastructure.Common.Middleware
{
	public class ProblemDetailsHandler : IProblemDetailsHandler
	{
		public const int Status499ClientClosedRequest = 499;

		public void HandleOptions(ProblemDetailsOptions options)
		{
			options.MapToStatusCode<PreConditionValidationException>(StatusCodes.Status400BadRequest);
			options.MapToStatusCode<ETagValidationException>(StatusCodes.Status400BadRequest);
			options.MapToStatusCode<InvalidFormatException>(StatusCodes.Status400BadRequest);

			options.MapToStatusCode<ItemNotFoundException>(StatusCodes.Status400BadRequest);
			options.MapToStatusCode<FileNotFoundException>(StatusCodes.Status400BadRequest);

			options.MapToStatusCode<CosmosOperationCanceledException>(Status499ClientClosedRequest);
			options.MapToStatusCode<OperationCanceledException>(Status499ClientClosedRequest);

			options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);
		}
	}
}