using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PriceParser.Infrastructure.Common.Swagger
{
	[ExcludeFromCodeCoverage]
	public abstract class ConfigureSwaggerOptionsBase
	{
		public abstract IEnumerable<(string GroupName, string GroupTitle, string Version)> Groups { get; }

		public void Configure(SwaggerGenOptions options)
		{
			foreach (var group in Groups)
			{
				options.SwaggerDoc(group.GroupName, CreateGroupDefinition(group));
			}
		}

		private OpenApiInfo CreateGroupDefinition((string GroupName, string GroupTitle, string Version) group)
		{
			var info = new OpenApiInfo()
			{
				Title = group.GroupTitle,
				Version = group.Version
			};

			return info;
		}
	}
}
