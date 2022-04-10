using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;

namespace FlightBookings.Infra.Data.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly FlightBookingsDbContext context;

        public AirportRepository(FlightBookingsDbContext context)
        {
            this.context = context;
        }

        public int Add(Airport airport)
        {
            context.Airports.Add(airport);
            return context.SaveChanges();
        }

        public int Delete(Guid id)
        {
            context.Airports.Remove(new Airport
            {
                Id = id
            });

            return context.SaveChanges();
        }

        public IQueryable<Airport> GetAll()
        {
            return context.Airports;
        }

        public Airport? GetById(Guid id)
        {
            return context.Airports.Find(id);
        }

        public int Update(Airport airport)
        {
            context.Airports.Update(airport);
            return context.SaveChanges();
        }
    }
}
