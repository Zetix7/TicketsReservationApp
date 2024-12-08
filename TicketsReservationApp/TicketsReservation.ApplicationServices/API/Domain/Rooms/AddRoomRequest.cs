using MediatR;

namespace TicketsReservation.ApplicationServices.API.Domain.Rooms;

public class AddRoomRequest : IRequest<AddRoomResponse>
{
    public bool IsScreen3d { get; set; }
    public int PremiumSeatsCount { get; set; }
    public int RegularSeatsCount { get; set; }
}
