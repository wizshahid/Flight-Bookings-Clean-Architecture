using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;

namespace FlightBookings.Application.Interfaces;

public interface IAirportService
{
    AirportResponse Add(CreateAirportRequest airportRequest);

    AirportResponse Update(UpdateAirportRequest airportRequest);

    AirportResponse GetById(Guid id);

    List<AirportResponse> GetAirports();

    void Delete(Guid id);
}
