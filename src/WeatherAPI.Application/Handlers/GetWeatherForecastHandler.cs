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
    // Handles the GetWeatherForecastQuery request and returns a weather forecast result.
    // Implements MediatR IRequestHandler interface to process the query asynchronously.
    public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastQuery, Result<WeatherForecastDto>>
    {
        private readonly IWeatherService _weatherService;

        public GetWeatherForecastHandler(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        // Handles the incoming GetWeatherForecastQuery request
        // Returns a Result object containing WeatherForecastDto if successful
        public async Task<Result<WeatherForecastDto>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Calls the weather service to fetch the weather forecast for the specified location
                // and number of days requested in the query.
                var forecast = await _weatherService.GetWeatherForecastAsync(request.Location, request.Days);

                if (forecast == null)
                    return Result<WeatherForecastDto>.Failure("Forecast data not found for the specified location.");

                var dto = new WeatherForecastDto
                {
                    Location = forecast.Location,
                    Country = forecast.Country,
                    Forecast = forecast.Forecast.Select(f => new DailyForecastDto
                    {
                        Date = f.Date,
                        MaxTempC = f.MaxTempC,
                        MinTempC = f.MinTempC,
                        Condition = f.Condition,
                        ConditionIcon = f.ConditionIcon,
                        ChanceOfRain = f.ChanceOfRain,
                        MaxWindKph = f.MaxWindKph,
                        AvgHumidity = f.AvgHumidity,
                        UvIndex = f.UvIndex
                    }).ToList()
                };

                return Result<WeatherForecastDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<WeatherForecastDto>.Failure($"Error retrieving forecast data: {ex.Message}");
            }
        }

    }
}