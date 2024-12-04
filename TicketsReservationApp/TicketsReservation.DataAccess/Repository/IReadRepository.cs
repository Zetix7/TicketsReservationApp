using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.Repository;

public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
}
