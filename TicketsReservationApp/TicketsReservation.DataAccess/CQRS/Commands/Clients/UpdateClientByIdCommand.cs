using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Clients;

public class UpdateClientByIdCommand : CommandBase<Client, Client>
{

    public override async Task<Client> Execute(TicketsReservationDbContext context)
    {
        var client = await context.Clients!.SingleOrDefaultAsync(x => x.Id == Parameter!.Id);

        if (client == null)
        {
            return new Client();
        }

        if (CommandsHelper.IsValidStringValue(Parameter!.FirstName!, client.FirstName!))
        {
            client.FirstName = Parameter!.FirstName;
        }

        if (CommandsHelper.IsValidStringValue(Parameter!.LastName!, client.LastName!))
        {
            client.LastName = Parameter!.LastName;
        }

        await context.SaveChangesAsync();
        return client;
    }
}
