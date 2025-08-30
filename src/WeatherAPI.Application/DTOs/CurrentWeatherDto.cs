using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Application.DTOs
{
    // DTO (Data Transfer Object) used to transfer current weather data 
    // from the API or service layer to the client application.
    public class CurrentWeatherDto
    {
        public string Location { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string ConditionIcon { get; set; } = string.Empty;
        public double WindKph { get; set; }
        public int Humidity { get; set; }
        public double FeelsLikeC { get; set; }
        public double UvIndex { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}