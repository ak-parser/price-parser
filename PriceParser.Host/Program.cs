using System.Reflection;
using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Identity.Web;
using PriceParser.Application.Common.Authentication.Contracts;
using PriceParser.Host.Common.Config.Dependencies;
using PriceParser.Infrastructure.Common.Middleware;
using PriceParser.Infrastructure.Common.Swagger.Utilities;
using PriceParser.Infrastructure.Common.Utilities.Contracts;

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

builder.Services.AddSwaggerGen(options =>
{
	options.DescribeAllParametersInCamelCase();
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
	options.OperationFilter<AddRequiredHeaderParameter>();
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
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
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
