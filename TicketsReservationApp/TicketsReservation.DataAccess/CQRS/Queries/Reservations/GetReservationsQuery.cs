using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Reservations;

public class GetReservationsQuery : QueryBase<List<Reservation>>
{
    public override Task<List<Reservation>> Execute(TicketsReservationDbContext context)
    {
        return context.Reservations!.ToListAsync();
    }
}
