using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FlightBookings.Infra.Data.Context;

internal class FlightBookingsDbContext : DbContext
{
    public FlightBookingsDbContext(DbContextOptions<FlightBookingsDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedUserData(modelBuilder);

        foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
        {
            relationShip.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    private void SeedUserData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = Guid.Parse("1b61edcd-aac5-4aeb-896a-6b197afe90d3"),
            Email = "admin@yopmail.com",
            PasswordHash = "$2a$11$x/VPHQFtPOID3//S/XkhMO9SWopKS6VYzdL0NkrnYmvu8SfzVGu9K",
            Salt = "$2a$11$x/VPHQFtPOID3//S/XkhMO",
            Username = "admin",
            Phone = "7889379123",
            Role = UserRole.Admin,
            Status = UserStatus.Active
        });
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;
    public DbSet<Airline> Airlines { get; set; } = null!;
    public DbSet<Inventory> Inventories { get; set; } = null!;
}
