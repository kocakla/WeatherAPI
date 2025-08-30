using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Infrastructure.Models
{
    public class DayData
    {
        [JsonPropertyName("maxtemp_c")]
        public double MaxtempC { get; set; }
        
        [JsonPropertyName("mintemp_c")]
        public double MintempC { get; set; }
        
        [JsonPropertyName("maxtemp_f")]
        public double MaxtempF { get; set; }
        
        [JsonPropertyName("mintemp_f")]
        public double MintempF { get; set; }
        
        [JsonPropertyName("avgtemp_c")]
        public double AvgtempC { get; set; }
        
        [JsonPropertyName("avgtemp_f")]
        public double AvgtempF { get; set; }
        
        [JsonPropertyName("condition")]
        public ConditionData Condition { get; set; } = new();
        
        [JsonPropertyName("daily_chance_of_rain")]
        public double DailyChanceOfRain { get; set; }
        
        [JsonPropertyName("maxwind_kph")]
        public double MaxwindKph { get; set; }
        
        [JsonPropertyName("maxwind_mph")]
        public double MaxwindMph { get; set; }
        
        [JsonPropertyName("avghumidity")]
        public int Avghumidity { get; set; }
        
        [JsonPropertyName("uv")]
        public double Uv { get; set; }
    }
}