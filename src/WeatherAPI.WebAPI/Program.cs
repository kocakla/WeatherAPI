
using WeatherAPI.Application;
using WeatherAPI.Infrastructure;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRateLimiter(options =>
{
    // Define a fixed window rate limiting policy.
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 5;     
        opt.Window = TimeSpan.FromSeconds(10); 
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opt.QueueLimit = 0;                
    });
    // Set the rejection status code for rate-limited requests.
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Configure Swagger for API documentation.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Weather API", Version = "v1" });
});

// Add Clean Architecture layers
builder.Services.AddApplicationServices();
// Add Infrastructure services with configuration
builder.Services.AddInfrastructureServices(builder.Configuration);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    // Enable Swagger in development environment.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// Enable rate limiting middleware.
app.UseRateLimiter();
// Apply rate limiting policy to controller routes.
app.MapControllers()
   .RequireRateLimiting("fixed"); 
   
app.Run();
