using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.Entities
{
    public class CurrentWeather
    {
        public string Location { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string ConditionIcon { get; set; } = string.Empty;
        public double WindKph { get; set; }
        public double WindMph { get; set; }
        public string WindDirection { get; set; } = string.Empty;
        public int Humidity { get; set; }
        public double FeelsLikeC { get; set; }
        public double FeelsLikeF { get; set; }
        public double UvIndex { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}