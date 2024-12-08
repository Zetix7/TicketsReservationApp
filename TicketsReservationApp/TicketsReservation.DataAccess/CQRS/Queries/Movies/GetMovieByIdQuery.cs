using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Movies;

public class GetMovieByIdQuery : QueryBase<Movie>
{
    public int Id { get; set; }

    public override Task<Movie> Execute(TicketsReservationDbContext context)
    {
        return context.Movies!.SingleOrDefaultAsync(x => x.Id == Id)!;
    }
}
