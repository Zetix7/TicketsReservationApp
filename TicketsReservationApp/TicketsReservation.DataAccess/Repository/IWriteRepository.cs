using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.Repository;

public interface IWriteRepository<in T> where T : class, IEntity
{
    void Insert(T entity);
    void Update(T entity);
    void Delete(int id);
}
