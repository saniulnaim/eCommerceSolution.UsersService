using eCommerce.API.Middleware;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;


var builder = WebApplication.CreateBuilder(args);

// Add DI services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the service collection
// AddJsonOptions > to bind enum object automatically. Here string will be convert to enum by JsonStringEnumConverter method.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Configure AutoMapper manually
builder.Services.AddSingleton<IMapper>(provider => 
{
    var loggerFactory = provider.GetService<ILoggerFactory>() ?? NullLoggerFactory.Instance;
    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<ApplicationUserMappingProfile>();
    }, loggerFactory);
    return config.CreateMapper();
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer(); // For API exploere services
builder.Services.AddSwaggerGen();

// Add cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

// Build the web application
var app = builder.Build();

// Custom middleware for exception handling
app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();

// swagger
app.UseSwagger(); // Add endpoint that can serve the swagger.json
app.UseSwaggerUI(); // Adds swagger UI

app.UseCors();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Enable routing for controllers
app.MapControllers();

app.Run();
