using System.Linq.Expressions;

namespace FlightBookings.Domain.Interfaces;

public interface IBaseRepository<T> where T : class
{
    int Add(T model);

    int Update(T model);

    T? GetById(Guid id);

    T? FirstOrDefault(Expression<Func<T, bool>> expression);

    bool Any(Expression<Func<T, bool>> expression);

    IQueryable<T> GetAll();

    IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

    int Delete(Guid id);
}
