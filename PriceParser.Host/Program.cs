using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;
using Lynkco.Warranty.WebAPI.Application.Common.Authentication.Contracts;
using Lynkco.Warranty.WebAPI.Application.Common.Authentication.Settings.Models;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Host.Common.Config.Dependencies;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Middleware;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Swagger.Utilities;
using Lynkco.Warranty.WebAPI.Infrastructure.Common.Utilities.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// TODO: CORS enabled for any origin as simplification for on the development phase and should be changed before deployment to production environment
var corsPolicy = "AllowOrigin";
builder.Services.AddCors(c =>
	c.AddPolicy(corsPolicy, options => options.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowAnyOrigin()));

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddMicrosoftIdentityWebApi(builder.Configuration);

IUserAuthenticationHandler authenticationHandler = null;
builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
{
	var existingOnTokenValidatedHandler = options.Events.OnTokenValidated;
	options.Events.OnTokenValidated = async context =>
	{
		await existingOnTokenValidatedHandler(context);
		await authenticationHandler.OnTokenValidatedHandler(context);
	};
});

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddProblemDetails(options =>
{
	var problemDetailsHandler = new ProblemDetailsHandler();
	problemDetailsHandler.HandleOptions(options);
}).AddProblemDetailsConventions();

IConfigProvider<AuthenticationSettings> authSettings = null;
builder.Services.AddSwaggerGen(options =>
{
	options.DescribeAllParametersInCamelCase();
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
	options.OperationFilter<AddRequiredHeaderParameter>();

	options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.OAuth2,
		Flows = new OpenApiOAuthFlows
		{
			Implicit = new OpenApiOAuthFlow
			{
				AuthorizationUrl = new Uri($"{authSettings.GetData().Instance}{authSettings.GetData().TenantId}/oauth2/v2.0/authorize"),
				TokenUrl = new Uri($"{authSettings.GetData().Instance}{authSettings.GetData().TenantId}/oauth2/v2.0/token"),
				Scopes = new Dictionary<string, string>
				{
					{ $"api://{authSettings.GetData().ClientId}/{authSettings.GetData().Scope}", "Access to the API" }
				}
			}
		}
	});
	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" },
				Scheme = "oauth2",
				Name = "oauth2",
				In = ParameterLocation.Header
			},
			new[] { $"api://{authSettings.GetData().ClientId}/{authSettings.GetData().Scope}" }
		}
	});
});
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.RegisterDependencies();

// URI GET request length management
builder.Services.Configure<KestrelServerOptions>(options =>
{
	options.Limits.MaxRequestLineSize = 50000;
	options.Limits.MaxRequestBufferSize = 50000;
	options.Limits.MaxRequestHeadersTotalSize = 50000;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	authSettings = app.Services.GetRequiredService<IConfigProvider<AuthenticationSettings>>();
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		options.OAuthClientId(authSettings.GetData().ClientId);
		options.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
		{
			["activated"] = false
		};
	});
}

app.UseCors(corsPolicy);

app.UseAuthentication();

using (var serviceScope = app.Services.CreateScope())
{
	authenticationHandler = serviceScope.ServiceProvider.GetRequiredService<IUserAuthenticationHandler>();
}

app.UseAuthorization();

app.MapControllers();

app.UseProblemDetails();

// Create all non-existing containers
var cosmosDbContainersHandler = app.Services.GetRequiredService<ICosmosDbContainersHandler>();
await cosmosDbContainersHandler.CreateAllContainers();

app.Run();
