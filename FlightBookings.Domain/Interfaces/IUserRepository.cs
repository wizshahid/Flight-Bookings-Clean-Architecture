using FlightBookings.Domain.Entities;

namespace FlightBookings.Domain.Interfaces
{
    public interface IUserRepository 
    {
        public int Add(User user);

        public IQueryable<User> GetAll();
    }
}
