using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WeatherAPI.Domain.Entities;
using WeatherAPI.Domain.Interfaces;
using WeatherAPI.Infrastructure.Configuration;
using WeatherAPI.Infrastructure.Models;

namespace WeatherAPI.Infrastructure.Services
{
    // Service to interact with the external weather API.
    public class WeatherService : IWeatherService
    {
        // HTTP client for making requests.
        private readonly HttpClient _httpClient;
        // Configuration settings for the weather API.
        private readonly WeatherApiSettings _settings;
        // Constructor to initialize the service with HTTP client and settings.
        public WeatherService(HttpClient httpClient, IOptions<WeatherApiSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }
        // Method to get current weather data for a specified location.
        public async Task<CurrentWeather?> GetCurrentWeatherAsync(string location)
        {
            try
            {
                var url = $"{_settings.BaseUrl}/current.json?key={_settings.ApiKey}&q={Uri.EscapeDataString(location)}&aqi=no";

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<WeatherApiCurrentResponse>(jsonContent);

                if (apiResponse == null) return null;
                // Map the API response to the domain entity.
                return new CurrentWeather
                {
                    Location = apiResponse.Location.Name,
                    Country = apiResponse.Location.Country,
                    Region = apiResponse.Location.Region,
                    Latitude = apiResponse.Location.Lat,
                    Longitude = apiResponse.Location.Lon,
                    TemperatureC = apiResponse.Current.TempC,
                    TemperatureF = apiResponse.Current.TempF,
                    Condition = apiResponse.Current.Condition.Text,
                    ConditionIcon = apiResponse.Current.Condition.Icon,
                    WindKph = apiResponse.Current.WindKph,
                    WindMph = apiResponse.Current.WindMph,
                    WindDirection = apiResponse.Current.WindDir,
                    Humidity = apiResponse.Current.Humidity,
                    FeelsLikeC = apiResponse.Current.FeelslikeC,
                    FeelsLikeF = apiResponse.Current.FeelslikeF,
                    UvIndex = apiResponse.Current.Uv,
                    LastUpdated = DateTime.Parse(apiResponse.Current.LastUpdated)
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
        // Method to get weather forecast data for a specified location and number of days.
        public async Task<WeatherForecast?> GetWeatherForecastAsync(string location, int days = 3)
        {
            try
            {
                // Ensure the number of days is within the allowed range.
                var url = $"{_settings.BaseUrl}/forecast.json?key={_settings.ApiKey}&q={Uri.EscapeDataString(location)}&days={days}&aqi=no&alerts=no";
                // Make the HTTP GET request to the weather API.
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<WeatherApiForecastResponse>(jsonContent);

                if (apiResponse == null) return null;
                // Map the API response to the domain entity.
                return new WeatherForecast
                {
                    Location = apiResponse.Location.Name,
                    Country = apiResponse.Location.Country,
                    Forecast = apiResponse.Forecast.Forecastday.Select(f => new DailyForecast
                    {
                        Date = DateTime.Parse(f.Date),
                        MaxTempC = f.Day.MaxtempC,
                        MinTempC = f.Day.MintempC,
                        MaxTempF = f.Day.MaxtempF,
                        MinTempF = f.Day.MintempF,
                        AvgTempC = f.Day.AvgtempC,
                        AvgTempF = f.Day.AvgtempF,
                        Condition = f.Day.Condition.Text,
                        ConditionIcon = f.Day.Condition.Icon,
                        ChanceOfRain = f.Day.DailyChanceOfRain,
                        MaxWindKph = f.Day.MaxwindKph,
                        MaxWindMph = f.Day.MaxwindMph,
                        AvgHumidity = f.Day.Avghumidity,
                        UvIndex = f.Day.Uv
                    }).ToList()
                };
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}