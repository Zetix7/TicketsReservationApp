using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Reservations;

public class GetReservationByIdQuery : QueryBase<Reservation>
{
    public int Id { get; set; }

    public override Task<Reservation> Execute(TicketsReservationDbContext context)
    {
        return context.Reservations!.SingleOrDefaultAsync(x => x.Id == Id)!;
    }
}
