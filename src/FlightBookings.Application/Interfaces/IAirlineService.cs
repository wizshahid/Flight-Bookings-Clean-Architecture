using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;

namespace FlightBookings.Application.Interfaces;

public interface IAirlineService
{
    Task<AirlineResponse> Add(CreateAirlineRequest airlineRequest);

    Task<AirlineResponse> Update(UpdateAirlineRequest airlineRequest);

    AirlineResponse GetById(Guid id);

    List<AirlineResponse> GetAirlines();

    Task Delete(Guid id);
}
