using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdRequest, GetRoomByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Room> _repository;

    public GetRoomByIdHandler(IRepository<DataAccess.Entities.Room> repository)
    {
        _repository = repository;
    }

    public Task<GetRoomByIdResponse> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
    {
        var room = _repository.GetById(request.Id);
        if (room == null)
        {
            room = new DataAccess.Entities.Room();
        }

        var domainRoom = new Room
        {
            IsScreen3d = room.IsScreen3d,
            PremiumSeatsCount = room.PremiumSeatsCount,
            RegularSeatsCount = room.RegularSeatsCount
        };
        var response = new GetRoomByIdResponse { Data = domainRoom };
        return Task.FromResult(response);
    }
}