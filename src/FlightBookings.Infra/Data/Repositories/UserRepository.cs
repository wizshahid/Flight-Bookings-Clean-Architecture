using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;

namespace FlightBookings.Infra.Data.Repositories;

internal class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(FlightBookingsDbContext context) : base(context)
    {
    }
}
