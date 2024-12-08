using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Screenings;

public class AddScreeningCommand : CommandBase<Screening, Screening>
{
    public override async Task<Screening> Execute(TicketsReservationDbContext context)
    {
        await context.Screenings!.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
