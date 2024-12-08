using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Reservations;

public class AddReservationRequest : IRequest<AddReservationResponse>
{
    public int ClientId { get; set; }
    public int ScreeningId { get; set; }
    public char RowLetterSeatPlace { get; set; }
    public int NumberSeatPlace { get; set; }
    public bool IsPremiumSeatPlace { get; set; }
    public decimal Price { get; set; }
}
