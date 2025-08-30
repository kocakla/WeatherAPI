using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Application.DTOs
{
    // DTO (Data Transfer Object) that represents a weather forecast result.
    // Typically contains multiple daily forecast records returned to the client.
    public class WeatherForecastDto
    {
        public string Location { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        // A list of daily forecast entries (e.g., upcoming 3 days).
        // Each entry contains minimum/maximum temperature, humidity, wind, and condition details.
        public List<DailyForecastDto> Forecast { get; set; } = new();
    }
}