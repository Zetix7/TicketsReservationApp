using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Screenings;

public class UpdateScreeningByIdCommand : CommandBase<Screening, Screening>
{
    public override async Task<Screening> Execute(TicketsReservationDbContext context)
    {
        var screening = await context.Screenings!.SingleOrDefaultAsync(x => x.Id == Parameter!.Id);

        if (screening == null)
        {
            return new Screening();
        }

        if(screening.MovieId != Parameter!.MovieId)
        {
            screening.MovieId = Parameter!.MovieId;
        }

        if (screening.RoomId != Parameter!.RoomId)
        {
            screening.RoomId = Parameter!.RoomId;
        }

        if (screening.DisplayDate != Parameter!.DisplayDate)
        {
            screening.DisplayDate = Parameter!.DisplayDate;
        }

        await context.SaveChangesAsync();
        return screening;
    }
}
