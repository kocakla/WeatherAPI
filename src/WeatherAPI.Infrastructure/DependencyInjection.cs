using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherAPI.Domain.Interfaces;
using WeatherAPI.Infrastructure.Configuration;
using WeatherAPI.Infrastructure.Services;

namespace WeatherAPI.Infrastructure
{
    public static class DependencyInjection
    {
        // Extension method to add infrastructure services to the service collection.
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure WeatherApiSettings from configuration.
            services.Configure<WeatherApiSettings>(configuration.GetSection(WeatherApiSettings.SectionName));
            // Register WeatherService with HTTP client support.
            services.AddHttpClient<IWeatherService, WeatherService>();

            return services;
        }
    }
}