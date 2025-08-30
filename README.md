  # WeatherAPI

![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![C#](https://img.shields.io/badge/C%23-Language-green)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

A Clean Architecture-based .NET 9 WebAPI that provides current weather and daily forecasts for a given location.

## Features

- Fetch current weather data (temperature, humidity, wind, condition)
- Retrieve multi-day forecasts (default 3 days)
- Built with Clean Architecture: Domain, Application, Infrastructure, WebAPI layers
- CQRS pattern with MediatR for queries and handlers
- Rate limiting middleware for API requests
- Asynchronous services and dependency injection

## Technology Stack

- .NET 9
- C#
- MediatR
- ASP.NET Core WebAPI
- System.Text.Json for JSON serialization

## Architecture Overview

![Clean Architecture](WeatherAPI/images/ArchtitectureOverview.png)

## Examples (Current and Forecast Weather)

![Current Weather](WeatherAPI/images/CurrentWeatherExample.png)
![Forecast Weather](WeatherAPI/images/ForecastWeatherExample.png)


## Getting Started

Clone the repository:
```bash
git clone https://github.com/kocakla/WeatherAPI.git
cd WeatherAPI/src/WeatherAPI.WebAPI
dotnet restore
dotnet run

Access the API endpoints (e.g., using Swagger):
GET /api/currentweather?location=London
GET /api/weatherforecast?location=London&days=3

API settings are stored in appsettings.json under the WeatherApi:
"WeatherApi": {
  "BaseUrl": "https://api.example.com",
  "ApiKey": "YOUR_API_KEY",
  "DefaultForecastDays": 3
}
