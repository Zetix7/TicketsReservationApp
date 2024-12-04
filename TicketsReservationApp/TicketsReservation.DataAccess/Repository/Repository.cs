using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly TicketsReservationDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(TicketsReservationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T? GetById(int id)
    {
        return _dbSet.SingleOrDefault(x => x.Id == id);
    }

    public void Insert(T entity)
    {
        if (entity == null)
        {
            return;
        }

        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            return;
        }

        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }
    public void Delete(int id)
    {
        var itemToRemove = _dbSet.FirstOrDefault(x => x.Id == id);
        if (itemToRemove == null)
        {
            return;
        }

        _dbSet.Remove(itemToRemove);
        _dbContext.SaveChanges();
    }
}
