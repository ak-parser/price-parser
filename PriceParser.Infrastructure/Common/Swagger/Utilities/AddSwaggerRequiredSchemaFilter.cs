using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Swagger.Utilities
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
