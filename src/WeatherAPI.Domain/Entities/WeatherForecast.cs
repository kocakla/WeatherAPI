using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.Entities
{
    public class WeatherForecast
    {
        public string Location { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<DailyForecast> Forecast { get; set; } = new();
    }
}