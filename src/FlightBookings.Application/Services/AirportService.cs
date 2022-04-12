using AutoMapper;
using AutoMapper.QueryableExtensions;
using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;
using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Exceptions;
using FlightBookings.Domain.Interfaces;

namespace FlightBookings.Application.Services;

public class AirportService : IAirportService
{
    private readonly IAirportRepository repository;
    private readonly IMapper mapper;

    public AirportService(IAirportRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public AirportResponse Add(CreateAirportRequest airportRequest)
    {
        if (repository.Any(x => x.Name == airportRequest.Name))
            throw new AppException($"Airport with name {{{airportRequest.Name}}} already exists");

        var airport = mapper.Map<Airport>(airportRequest);
        repository.Add(airport);
        return mapper.Map<AirportResponse>(airport);
    }

    public void Delete(Guid id)
    {
        repository.Delete(id);
    }

    public List<AirportResponse> GetAirports()
    {
        return repository.GetAll().ProjectTo<AirportResponse>(mapper.ConfigurationProvider).ToList();
    }

    public AirportResponse GetById(Guid id)
    {
        return mapper.Map<AirportResponse>(repository.GetById(id));
    }

    public AirportResponse Update(UpdateAirportRequest airportRequest)
    {
        var airport = mapper.Map<Airport>(airportRequest);
        repository.Update(airport);
        return mapper.Map<AirportResponse>(airport);
    }
}
