using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Infrastructure.Models
{
    public class ForecastDayData
    {
        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;
        
        [JsonPropertyName("day")]
        public DayData Day { get; set; } = new();
    }
}