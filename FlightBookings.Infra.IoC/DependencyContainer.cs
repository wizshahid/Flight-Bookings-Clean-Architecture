using FlightBookings.Application.AutoMapper;
using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Services;
using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;
using FlightBookings.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookings.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Infra layer dependencies
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAirportRepository, AirportRepository>();

            //Application layer dependencies
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAirportService, AirportService>();

            services.AddAutoMapper(typeof(IAutoMapperMarker));

            return services;
        }
    }
}
