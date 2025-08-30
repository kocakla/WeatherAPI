using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Infrastructure.Models
{
    public class CurrentData
    {
        [JsonPropertyName("temp_c")]
        public double TempC { get; set; }
        
        [JsonPropertyName("temp_f")]
        public double TempF { get; set; }
        
        [JsonPropertyName("condition")]
        public ConditionData Condition { get; set; } = new();
        
        [JsonPropertyName("wind_kph")]
        public double WindKph { get; set; }
        
        [JsonPropertyName("wind_mph")]
        public double WindMph { get; set; }
        
        [JsonPropertyName("wind_dir")]
        public string WindDir { get; set; } = string.Empty;
        
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        
        [JsonPropertyName("feelslike_c")]
        public double FeelslikeC { get; set; }
        
        [JsonPropertyName("feelslike_f")]
        public double FeelslikeF { get; set; }
        
        [JsonPropertyName("uv")]
        public double Uv { get; set; }
        
        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; } = string.Empty;
    }
}