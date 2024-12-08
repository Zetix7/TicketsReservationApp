using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Movies;

public class AddMovieCommand : CommandBase<Movie, Movie>
{
    public override async Task<Movie> Execute(TicketsReservationDbContext context)
    {
        await context.Movies!.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
