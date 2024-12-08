using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetRoomsHandler : IRequestHandler<GetRoomsRequest, GetRoomsResponse>
{
    private readonly IRepository<DataAccess.Entities.Room> _repository;
    private readonly IMapper _mapper;

    public GetRoomsHandler(IRepository<DataAccess.Entities.Room> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetRoomsResponse> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {
        var rooms = await _repository.GetAll();
        var mappedRooms = _mapper.Map<List<Room>>(rooms);
        var response = new GetRoomsResponse { Data = mappedRooms };
        return response;
    }
}
