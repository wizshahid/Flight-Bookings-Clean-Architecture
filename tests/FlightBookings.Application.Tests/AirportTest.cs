using AutoMapper;
using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Response;
using FlightBookings.Application.Services;
using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FlightBookings.Application.Tests;
public class AirportTest
{
    public Mock<IAirportRepository> mock = new Mock<IAirportRepository>();
    public Mock<IMapper> map = new Mock<IMapper>();

    [Fact]
    public void TestGetAll()
    {
        var id = Guid.NewGuid();
        var airport = new Airport
        {
            Id = id,
            City = "Srinagar"
        };
        mock.Setup(p => p.GetById(id)).Returns(airport);
        map.Setup(m => m.Map<Airport, AirportResponse>(It.IsAny<Airport>())).Returns(new AirportResponse());
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new SourceMappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        IAirportService airportService = new AirportService(mock.Object, mapper);
        var result =  airportService.GetById(id);
        Assert.Equal(result.City, airport.City);
    }

    public class SourceMappingProfile : Profile
    {
        public SourceMappingProfile()
        {
            CreateMap<Airport, AirportResponse>();
        }
    }

}
