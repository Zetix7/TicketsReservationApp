using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Rooms;

public class GetRoomsQuery : QueryBase<List<Room>>
{
    public override Task<List<Room>> Execute(TicketsReservationDbContext context)
    {
        return context.Rooms!.ToListAsync();
    }
}
