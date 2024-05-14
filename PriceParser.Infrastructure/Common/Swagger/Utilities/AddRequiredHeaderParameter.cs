using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Swagger.Utilities
{
	[ExcludeFromCodeCoverage]
	public class AddRequiredHeaderParameter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			if (operation.Parameters == null)
			{
				operation.Parameters = new List<OpenApiParameter>();
			}

			operation.Parameters.Add(new OpenApiParameter
			{
				Name = "X-Time-Zone",
				In = ParameterLocation.Header,
				Description = "Clients local timezone offset in minutes (X % 60 == 0, From -720 to 720)",
				Required = true,
				Schema = new OpenApiSchema
				{
					Type = "string"
				}
			});
		}
	}
}
