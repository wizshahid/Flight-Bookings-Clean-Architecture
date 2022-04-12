using FlightBookings.Domain.Interfaces;
using FlightBookings.Infra.Data.Context;
using System.Linq.Expressions;

namespace FlightBookings.Infra.Data.Repositories;

internal class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly FlightBookingsDbContext context;

    public BaseRepository(FlightBookingsDbContext context)
    {
        this.context = context;
    }

    public int Add(T model)
    {
        context.Set<T>().Add(model);
        return context.SaveChanges();
    }

    public int Delete(Guid id)
    {
        var item = GetById(id);

        if (item is null)
            return 0;

        context.Remove(item);

        return context.SaveChanges();
    }

    public T? FirstOrDefault(Expression<Func<T, bool>> expression)
    {
       return GetAll().FirstOrDefault(expression);
    }

    public bool Any(Expression<Func<T, bool>> expression)
    {
        return GetAll().Any(expression);
    }

    public IQueryable<T> GetAll()
    {
        return context.Set<T>();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
    {
        return GetAll().Where(expression);
    }

    public T? GetById(Guid id)
    {
        return context.Set<T>().Find(id);
    }

    public int Update(T model)
    {
        context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return context.SaveChanges();
    }
}
