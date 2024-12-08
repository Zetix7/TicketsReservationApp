using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;
using TicketsReservation.DataAccess.CQRS.Commands;
using TicketsReservation.DataAccess.CQRS.Commands.Rooms;

namespace TicketsReservation.ApplicationServices.API.Handlers.Rooms;

public class AddRoomHandler : IRequestHandler<AddRoomRequest, AddRoomResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddRoomHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddRoomResponse> Handle(AddRoomRequest request, CancellationToken cancellationToken)
    {
        var room = _mapper.Map<DataAccess.Entities.Room>(request);
        var command = new AddRoomCommand { Parameter = room };
        room = await _commandExecutor.Execute(command);
        var domainRoom = _mapper.Map<Room>(room);
        return new AddRoomResponse { Data = domainRoom };
    }
}
