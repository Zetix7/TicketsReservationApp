using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Movies;

public class UpdateMovieByIdCommand : CommandBase<Movie, Movie>
{
    public override async Task<Movie> Execute(TicketsReservationDbContext context)
    {
        var movie = await context.Movies!.SingleOrDefaultAsync(x => x.Id == Parameter!.Id);

        if (movie == null)
        {
            return new Movie();
        }

        if (CommandsHelper.IsValidStringValue(Parameter!.Title!, movie.Title!))
        {
            movie.Title = Parameter!.Title;
        }

        if (Parameter!.Duration > 1 && movie.Duration != Parameter!.Duration)
        {
            movie.Duration = Parameter!.Duration;
        }

        await context.SaveChangesAsync();
        return Parameter;
    }
}
