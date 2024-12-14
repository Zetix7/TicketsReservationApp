using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Screenings;

public class UpdateScreeningByIdRequest : IRequest<UpdateScreeningByIdResponse>
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int RoomId { get; set; }
    public DateTime DisplayDate { get; set; }
}
