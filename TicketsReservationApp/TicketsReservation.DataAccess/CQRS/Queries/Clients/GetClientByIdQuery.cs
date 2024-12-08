using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Clients;

public class GetClientByIdQuery : QueryBase<Client>
{
    public int Id { get; set; }

    public override Task<Client> Execute(TicketsReservationDbContext context)
    {
        return context.Clients!.SingleOrDefaultAsync(x => x.Id == Id)!;
    }
}
