using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Domain.Entities;

namespace WeatherAPI.Domain.Interfaces
{
    // Provides methods to retrieve current weather and forecast data asynchronously.
    public interface IWeatherService
    {
        // Returns a CurrentWeather object or null if the data is not available.
        Task<CurrentWeather?> GetCurrentWeatherAsync(string location);
        // Default is 3 days. Returns a WeatherForecast object or null if data is not available.
        Task<WeatherForecast?> GetWeatherForecastAsync(string location, int days = 3);
    }
}