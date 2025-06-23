using System.Diagnostics.CodeAnalysis;

namespace PriceParser.Infrastructure.Common.Swagger.Attributes
{
	[ExcludeFromCodeCoverage]
	[AttributeUsage(AttributeTargets.Property)]
	public class SwaggerRequiredAttribute : Attribute
	{
	}
}
