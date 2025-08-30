using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Infrastructure.Models
{
    public class ConditionData
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
        
        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }
}