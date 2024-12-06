using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Rooms;

public class GetRoomByIdRequest : IRequest<GetRoomByIdResponse>
{
    public int Id { get; set; }
}
