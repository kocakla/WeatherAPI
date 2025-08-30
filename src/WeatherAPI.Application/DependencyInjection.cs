using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherAPI.Application
{
    public static class DependencyInjection
    {
        // Extension method to register application-layer services into the DI container.
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registers MediatR handlers from the current assembly (e.g., queries, commands, handlers)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}