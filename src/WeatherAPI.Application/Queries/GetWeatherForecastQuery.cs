using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WeatherAPI.Application.DTOs;
using WeatherAPI.Domain.Common;


namespace WeatherAPI.Application.Queries
{
        // Represents a query to request a weather forecast for a specific location.
        // Implements MediatR IRequest interface with a response type of Result<WeatherForecastDto>.
        public record GetWeatherForecastQuery(string Location, int Days = 3) : IRequest<Result<WeatherForecastDto>>;        
}