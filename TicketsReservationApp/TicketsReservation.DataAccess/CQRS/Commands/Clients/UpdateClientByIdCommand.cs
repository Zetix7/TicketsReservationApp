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

        if (IsValidName(Parameter!.FirstName!, client.FirstName!))
        {
            client.FirstName = Parameter!.FirstName;
        }

        if (IsValidName(Parameter!.LastName!, client.LastName!))
        {
            client.LastName = Parameter!.LastName;
        }

        await context.SaveChangesAsync();
        return Parameter!;
    }

    private static bool IsValidName(string name, string clientName)
    {
        return !string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) && clientName != name;
    }
}
