using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Infrastructure.Models
{
    // returned by the external weather API.
    public class WeatherApiCurrentResponse
    {
        // mapped from the "location" property in the JSON response.
        [JsonPropertyName("location")]
        public LocationData Location { get; set; } = new();
        // mapped from the "current" property in the JSON response.    
        [JsonPropertyName("current")]
        public CurrentData Current { get; set; } = new();
    }
}