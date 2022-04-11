using FlightBookings.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightBookings.Infra.Data.Context
{
    public class FlightBookingsDbContext : DbContext
    {
        public FlightBookingsDbContext(DbContextOptions<FlightBookingsDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Airport> Airports { get; set; } = null!;
        public DbSet<Airline> Airlines { get; set; } = null!;
    }
}
