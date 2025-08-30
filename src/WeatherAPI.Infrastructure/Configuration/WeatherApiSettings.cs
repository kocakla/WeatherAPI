using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Infrastructure.Configuration
{
    // Represents the configuration settings for the external weather API.
    // Typically bound from the "WeatherApi" section in appsettings.json.
    public class WeatherApiSettings
    {
        // Name of the configuration section in appsettings.json
        public const string SectionName = "WeatherApi";
        public string ApiKey { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = "http://api.weatherapi.com/v1";
    }
}