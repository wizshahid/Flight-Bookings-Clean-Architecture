using FlightBookings.Application.Models.Request;

namespace FlightBookings.Application.Models.Response
{
    public class AirlineResponse : UpdateAirlineRequest
    {
        public string? LogoPath { get; set; }
    }
}
