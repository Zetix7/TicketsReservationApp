using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Rooms;

public class AddRoomCommand : CommandBase<Room, Room>
{
    public override async Task<Room> Execute(TicketsReservationDbContext context)
    {
        await context.Rooms!.AddAsync(Parameter!);
        await context.SaveChangesAsync();
        return Parameter!;
    }
}
