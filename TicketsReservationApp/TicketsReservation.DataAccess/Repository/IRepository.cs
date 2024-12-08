using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.Repository;

public interface IRepository<T> where T : class, IEntity
{
    Task<List<T>> GetAll();
    Task<T>? GetById(int id);
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(int id);
}
