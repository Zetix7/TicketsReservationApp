using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Reservations;

public class GetReservationByIdRequest : IRequest<GetReservationByIdResponse>
{
    public int Id { get; set; }
}
