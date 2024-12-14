using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Rooms;

public class UpdateRoomByIdCommand : CommandBase<Room, Room>
{
    public override async Task<Room> Execute(TicketsReservationDbContext context)
    {
        var room = await context.Rooms!.SingleOrDefaultAsync(x => x.Id == Parameter!.Id);

        if (room == null)
        {
            return new Room();
        }

        if (room.IsScreen3d != Parameter!.IsScreen3d)
        {
            room.IsScreen3d = Parameter!.IsScreen3d;
        }

        if (int.IsPositive(Parameter!.RegularSeatsCount) && room.RegularSeatsCount != Parameter!.RegularSeatsCount)
        {
            room.RegularSeatsCount = Parameter!.RegularSeatsCount;
        }

        if (int.IsPositive(Parameter!.PremiumSeatsCount) && room.PremiumSeatsCount != Parameter!.PremiumSeatsCount)
        {
            room.PremiumSeatsCount = Parameter!.PremiumSeatsCount;
        }

        await context.SaveChangesAsync();
        return room;
    }
}
