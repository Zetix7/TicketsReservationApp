using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.Repository;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
{
}
