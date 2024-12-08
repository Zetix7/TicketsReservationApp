using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Queries.Rooms;

public class GetRoomByIdQuery : QueryBase<Room>
{
    public int Id { get; set; }

    public override Task<Room> Execute(TicketsReservationDbContext context)
    {
        return context.Rooms!.SingleOrDefaultAsync(x => x.Id == Id)!;
    }
}
