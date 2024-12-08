using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Movies;

public class GetMoviesQuery : QueryBase<List<Movie>>
{
    public override Task<List<Movie>> Execute(TicketsReservationDbContext context)
    {
        return context.Movies!.ToListAsync();
    }
}
