using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Screenings;

public class GetScreeningByIdQuery : QueryBase<Screening>
{
    public int Id { get; set; }

    public override Task<Screening> Execute(TicketsReservationDbContext context)
    {
        return context.Screenings!.SingleOrDefaultAsync(x => x.Id == Id)!;
    }
}
