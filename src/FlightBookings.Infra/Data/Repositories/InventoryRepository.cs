using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;

namespace FlightBookings.Infra.Data.Repositories;
internal class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
{
    public InventoryRepository(FlightBookingsDbContext context) : base(context)
    {
    }
}
