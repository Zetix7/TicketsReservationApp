using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Rooms;

namespace TicketsReservation.ApplicationServices.API.Handlers.Rooms;

public class GetRoomsHandler : IRequestHandler<GetRoomsRequest, GetRoomsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetRoomsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetRoomsResponse> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetRoomsQuery();
        var rooms = await _queryExecutor.Execute(query);
        var mappedRooms = _mapper.Map<List<Room>>(rooms);
        var response = new GetRoomsResponse { Data = mappedRooms };
        return response;
    }
}
