using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Application.Queries;

namespace WeatherAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        // Mediator for handling requests.
        private readonly IMediator _mediator;
        // Constructor to initialize the controller with the mediator.
        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get current weather for a location
        /// </summary>
        /// <param name="location">Location name (city, coordinates, etc.)</param>
        /// <returns>Current weather information</returns>
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather([FromQuery] string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return BadRequest("Location parameter is required.");

            var query = new GetCurrentWeatherQuery(location);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Data);
        }

        /// <summary>
        /// Get weather forecast for a location
        /// </summary>
        /// <param name="location">Location name (city, coordinates, etc.)</param>
        /// <param name="days">Number of forecast days (1-10, default: 3)</param>
        /// <returns>Weather forecast information</returns>
        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeatherForecast([FromQuery] string location, [FromQuery] int days = 3)
        {
            if (string.IsNullOrWhiteSpace(location))
                return BadRequest("Location parameter is required.");

            if (days < 1 || days > 10)
                return BadRequest("Days must be between 1 and 10.");

            var query = new GetWeatherForecastQuery(location, days);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Data);
        }
    }
}