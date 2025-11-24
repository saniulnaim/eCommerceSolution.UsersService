using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options=>
{
  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();

// Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// Routing For Controllers
app.MapControllers();

// Auth
// Authentication must come before Authorization
app.UseAuthentication();
app.UseAuthorization();

app.Run();
