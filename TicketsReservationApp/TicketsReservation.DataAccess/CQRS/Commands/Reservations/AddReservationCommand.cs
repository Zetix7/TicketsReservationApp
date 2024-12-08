using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Reservations;

public class AddReservationCommand : CommandBase<Reservation, Reservation>
{
    public override async Task<Reservation> Execute(TicketsReservationDbContext context)
    {
        await context.Reservations!.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
