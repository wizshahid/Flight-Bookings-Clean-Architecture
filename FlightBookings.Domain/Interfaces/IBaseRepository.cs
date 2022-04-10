namespace FlightBookings.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        int Add(T model);

        int Update(T model);

        T? GetById(Guid id);

        IQueryable<T> GetAll();

        int Delete(Guid id);
    }
}
