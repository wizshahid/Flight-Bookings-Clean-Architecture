using AutoMapper;
using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Services;
using FlightBookings.Application.Tests.Utils;
using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;
using Moq;
using System;
using Xunit;

namespace FlightBookings.Application.Tests;
public class AirportTest
{
    public Mock<IAirportRepository> mock = new();

    [Fact]
    public void TestGetAll()
    {
        var id = Guid.NewGuid();
        Airport airport = new()
        {
            Id = id,
            City = "Srinagar"
        };
        mock.Setup(p => p.GetById(id)).Returns(airport);
        IMapper mapper = AppMapper.GetMapper();
        IAirportService airportService = new AirportService(mock.Object, mapper);
        var result = airportService.GetById(id);
        Assert.Equal(result.City, airport.City);
    }
}
