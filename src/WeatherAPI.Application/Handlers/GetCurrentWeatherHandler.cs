using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WeatherAPI.Application.DTOs;
using WeatherAPI.Application.Queries;
using WeatherAPI.Domain.Common;
using WeatherAPI.Domain.Interfaces;

namespace WeatherAPI.Application.Handlers
{
    // Handles the GetCurrentWeatherQuery request and returns the current weather data.
    // Implements MediatR IRequestHandler interface to process the query asynchronously.
    public class GetCurrentWeatherHandler : IRequestHandler<GetCurrentWeatherQuery, Result<CurrentWeatherDto>>
    {
        private readonly IWeatherService _weatherService;

        public GetCurrentWeatherHandler(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        // Handles the incoming GetCurrentWeatherQuery request
        // Returns a Result object containing CurrentWeatherDto if successful
        public async Task<Result<CurrentWeatherDto>> Handle(GetCurrentWeatherQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var weather = await _weatherService.GetCurrentWeatherAsync(request.Location);

                if (weather == null)
                    return Result<CurrentWeatherDto>.Failure("Weather data not found for the specified location.");

                var dto = new CurrentWeatherDto
                {
                    Location = weather.Location,
                    Country = weather.Country,
                    Region = weather.Region,
                    TemperatureC = weather.TemperatureC,
                    TemperatureF = weather.TemperatureF,
                    Condition = weather.Condition,
                    ConditionIcon = weather.ConditionIcon,
                    WindKph = weather.WindKph,
                    Humidity = weather.Humidity,
                    FeelsLikeC = weather.FeelsLikeC,
                    UvIndex = weather.UvIndex,
                    LastUpdated = weather.LastUpdated
                };

                return Result<CurrentWeatherDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<CurrentWeatherDto>.Failure($"Error retrieving weather data: {ex.Message}");
            }
        }
    }
}