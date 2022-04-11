using FlightBookings.Application.AutoMapper;
using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Services;
using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;
using FlightBookings.Infra.Data.Repositories;
using FlightBookings.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightBookings.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration, string webRootPath)
        {
            //Infra layer dependencies
            services.AddDbContext<FlightBookingsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FlightBookingsConnection"));
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IAirlineRepository, AirlineRepository>();
            services.AddSingleton<IFileService>(new FileService(webRootPath));

            //Application layer dependencies
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<IAirlineService, AirlineService>();

            services.AddAutoMapper(typeof(IAutoMapperMarker));

            return services;
        }
    }
}
