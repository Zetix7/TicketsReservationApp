using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Screenings;

public class AddScreeningRequest : IRequest<AddScreeningResponse>
{
    public int MovieId { get; set; }
    public int RoomId { get; set; }
    public DateTime DisplayDate { get; set; }
}
