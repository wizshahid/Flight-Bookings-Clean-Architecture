using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;

namespace FlightBookings.Infra.Data.Repositories;

internal class AirlineRepository : BaseRepository<Airline>, IAirlineRepository
{
    public AirlineRepository(FlightBookingsDbContext context) : base(context)
    {
    }
}
