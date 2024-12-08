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

    public Task<List<T>> GetAll()
    {
        return _dbSet.ToListAsync();
    }

    public Task<T>? GetById(int id)
    {
        return _dbSet.SingleOrDefaultAsync(x => x.Id == id)!;
    }

    public Task Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("Entity is null");
        }

        _dbSet.Add(entity);
        return _dbContext.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("Entity is null");
        }

        _dbSet.Update(entity);
        return _dbContext.SaveChangesAsync();
    }
    public Task Delete(int id)
    {
        var itemToRemove = _dbSet.FirstOrDefault(x => x.Id == id);
        if (itemToRemove == null)
        {
            throw new ArgumentNullException("Entity is null");
        }

        _dbSet.Remove(itemToRemove);
        return _dbContext.SaveChangesAsync();
    }
}
