using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;

namespace FlightBookings.Infra.Data.Repositories;

internal class AirportRepository : BaseRepository<Airport>, IAirportRepository
{
    public AirportRepository(FlightBookingsDbContext context) : base(context)
    {
    }
}
