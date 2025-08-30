using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Application.DTOs
{
    // DTO (Data Transfer Object) that represents daily weather forecast information.
    // Used to transfer forecast data from the application layer to the presentation layer (e.g., API).
    public class DailyForecastDto
    {
        public DateTime Date { get; set; }
        public double MaxTempC { get; set; }
        public double MinTempC { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string ConditionIcon { get; set; } = string.Empty;
        public double ChanceOfRain { get; set; }
        public double MaxWindKph { get; set; }
        public int AvgHumidity { get; set; }
        public double UvIndex { get; set; }
    }
}