using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess.CQRS.Commands.Reservations;

public class UpdateReservationByIdCommand : CommandBase<Reservation, Reservation>
{
    public override async Task<Reservation> Execute(TicketsReservationDbContext context)
    {
        var reservation = await context.Reservations!.SingleOrDefaultAsync(x=>x.Id == Parameter!.Id);

        if (reservation == null)
        {
            return new Reservation();
        }

        if (reservation.ClientId != Parameter!.ClientId)
        {
            reservation.ClientId = Parameter!.ClientId;
        }

        if (reservation.ScreeningId != Parameter!.ScreeningId)
        {
            reservation.ScreeningId = Parameter!.ScreeningId;
        }

        if (Parameter!.RowLetterSeatPlace >= 'A' && Parameter!.RowLetterSeatPlace <= 'G' && reservation.RowLetterSeatPlace != Parameter!.RowLetterSeatPlace)
        {
            reservation.RowLetterSeatPlace = Parameter!.RowLetterSeatPlace;
        }

        if (int.IsPositive(Parameter!.NumberSeatPlace) && Parameter!.NumberSeatPlace < 8 && reservation.NumberSeatPlace != Parameter!.NumberSeatPlace)
        {
            reservation.NumberSeatPlace = Parameter!.NumberSeatPlace;
        }

        if (reservation.IsPremiumSeatPlace != Parameter!.IsPremiumSeatPlace)
        {
            reservation.IsPremiumSeatPlace = Parameter!.IsPremiumSeatPlace;
        }

        if (!decimal.IsNegative(Parameter!.Price) && reservation.Price != Parameter!.Price)
        {
            reservation.Price = Parameter!.Price;
        }

        await context.SaveChangesAsync();
        return reservation;
    }
}
