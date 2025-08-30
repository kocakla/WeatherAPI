using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Domain.Entities
{
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public double MaxTempC { get; set; }
        public double MinTempC { get; set; }
        public double MaxTempF { get; set; }
        public double MinTempF { get; set; }
        public double AvgTempC { get; set; }
        public double AvgTempF { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string ConditionIcon { get; set; } = string.Empty;
        public double ChanceOfRain { get; set; }
        public double MaxWindKph { get; set; }
        public double MaxWindMph { get; set; }
        public int AvgHumidity { get; set; }
        public double UvIndex { get; set; }
    }
}