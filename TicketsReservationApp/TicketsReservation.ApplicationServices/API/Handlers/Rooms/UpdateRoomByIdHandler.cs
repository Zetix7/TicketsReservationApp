using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;
using TicketsReservation.DataAccess.CQRS.Commands;
using TicketsReservation.DataAccess.CQRS.Commands.Rooms;

namespace TicketsReservation.ApplicationServices.API.Handlers.Rooms;

public class UpdateRoomByIdHandler : IRequestHandler<UpdateRoomByIdRequest, UpdateRoomByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateRoomByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }
        
    public async Task<UpdateRoomByIdResponse> Handle(UpdateRoomByIdRequest request, CancellationToken cancellationToken)
    {
        var room = _mapper.Map<DataAccess.Entities.Room>(request);
        var command = new UpdateRoomByIdCommand { Parameter = room };
        room = await _commandExecutor.Execute(command);
        var domainRoom = _mapper.Map<Room>(room);
        return new UpdateRoomByIdResponse { Data = domainRoom };
    }
}
