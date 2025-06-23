using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.OpenApi.Models;
using PriceParser.Infrastructure.Common.Swagger.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PriceParser.Infrastructure.Common.Swagger.Utilities
{
	[ExcludeFromCodeCoverage]
	public class AddSwaggerRequiredSchemaFilter : ISchemaFilter
	{
		public void Apply(OpenApiSchema schema, SchemaFilterContext context)
		{
			var properties = context.Type.GetProperties();
			foreach (var property in properties)
			{
				var attribute = property.GetCustomAttribute(typeof(SwaggerRequiredAttribute));

				if (attribute != null)
				{
					var propertyNameInCamelCasing = char.ToLowerInvariant(property.Name[0]) + property.Name[1..];

					if (schema.Required == null)
					{
						schema.Required = new HashSet<string>()
						{
							propertyNameInCamelCasing
						};
					}
					else
					{
						schema.Required.Add(propertyNameInCamelCasing);
					}
				}
			}
		}
	}
}
