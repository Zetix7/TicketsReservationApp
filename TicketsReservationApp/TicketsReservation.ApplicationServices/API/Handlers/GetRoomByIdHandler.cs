using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdRequest, GetRoomByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Room> _repository;
    private readonly IMapper _mapper;

    public GetRoomByIdHandler(IRepository<DataAccess.Entities.Room> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetRoomByIdResponse> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
    {
        var room = await _repository.GetById(request.Id)!;
        if (room == null)
        {
            room = new DataAccess.Entities.Room();
        }

        var mappedRoom = _mapper.Map<Room>(room);
        var response = new GetRoomByIdResponse { Data = mappedRoom };
        return response;
    }
}