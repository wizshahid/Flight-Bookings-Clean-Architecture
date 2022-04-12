using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;

namespace FlightBookings.Infra.Data.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly FlightBookingsDbContext _context;

    public UserRepository(FlightBookingsDbContext context)
    {
        _context = context;
    }

    public int Add(User user)
    {
        _context.Add(user);
        return _context.SaveChanges();
    }

    public IQueryable<User> GetAll()
    {
        return _context.Users;
    }
}
