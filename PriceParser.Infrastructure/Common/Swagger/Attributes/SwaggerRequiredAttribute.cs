using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Swagger.Attributes
{
	[ExcludeFromCodeCoverage]
	[AttributeUsage(AttributeTargets.Property)]
	public class SwaggerRequiredAttribute : Attribute
	{
	}
}
