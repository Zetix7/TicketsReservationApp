using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Screenings;

public class GetScreeningsQuery : QueryBase<List<Screening>>
{
    public override Task<List<Screening>> Execute(TicketsReservationDbContext context)
    {
        return context.Screenings!.ToListAsync();
    }
}
