using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Rooms;

public class UpdateRoomByIdRequest : IRequest<UpdateRoomByIdResponse>
{
    public int Id { get; set; }
    public bool IsScreen3d { get; set; }
    public int PremiumSeatsCount { get; set; }
    public int RegularSeatsCount { get; set; }
}
