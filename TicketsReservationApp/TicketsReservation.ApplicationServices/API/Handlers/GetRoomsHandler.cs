using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetRoomsHandler : IRequestHandler<GetRoomsRequest, GetRoomsResponse>
{
    private readonly IRepository<DataAccess.Entities.Room> _repository;

    public GetRoomsHandler(IRepository<DataAccess.Entities.Room> repository)
    {
        _repository = repository;
    }

    public Task<GetRoomsResponse> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {
        var rooms = _repository.GetAll();
        var domainRooms = rooms.Select(x => new Room
        {
            IsScreen3d = x.IsScreen3d,
            PremiumSeatsCount = x.PremiumSeatsCount,
            RegularSeatsCount = x.RegularSeatsCount
        }).ToList();

        var response = new GetRoomsResponse { Data = domainRooms };
        return Task.FromResult(response);
    }
}
