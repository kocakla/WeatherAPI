using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Infrastructure.Models
{
    public class ForecastData
    {
        [JsonPropertyName("forecastday")]
        public List<ForecastDayData> Forecastday { get; set; } = new();
    }
}