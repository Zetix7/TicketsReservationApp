using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Clients;

public class AddClientCommand : CommandBase<Client, Client>
{
    public override async Task<Client> Execute(TicketsReservationDbContext context)
    {
        await context.Clients!.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
