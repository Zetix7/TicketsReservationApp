using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;
using TicketsReservation.DataAccess.CQRS.Commands;
using TicketsReservation.DataAccess.CQRS.Commands.Reservations;

namespace TicketsReservation.ApplicationServices.API.Handlers.Reservations;

public class UpdateReservationByIdHandler : IRequestHandler<UpdateReservationByIdRequest, UpdateReservationByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateReservationByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateReservationByIdResponse> Handle(UpdateReservationByIdRequest request, CancellationToken cancellationToken)
    {
        var reservation = _mapper.Map<DataAccess.Entities.Reservation>(request);
        var command = new UpdateReservationByIdCommand { Parameter = reservation };
        reservation = await _commandExecutor.Execute(command);
        var domainReservation = _mapper.Map<Reservation>(reservation);
        return new UpdateReservationByIdResponse { Data = domainReservation };
    }
}
