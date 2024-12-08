using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Rooms;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdRequest, GetRoomByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetRoomByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetRoomByIdResponse> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetRoomByIdQuery { Id = request.Id };
        var room = await _queryExecutor.Execute(query);
        if (room == null)
        {
            room = new DataAccess.Entities.Room();
        }

        var mappedRoom = _mapper.Map<Room>(room);
        var response = new GetRoomByIdResponse { Data = mappedRoom };
        return response;
    }
}