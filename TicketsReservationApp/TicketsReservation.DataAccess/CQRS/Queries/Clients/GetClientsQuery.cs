using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Clients;

public class GetClientsQuery : QueryBase<List<Client>>
{
    public override Task<List<Client>> Execute(TicketsReservationDbContext context)
    {
        return context.Clients!.ToListAsync();
    }
}
