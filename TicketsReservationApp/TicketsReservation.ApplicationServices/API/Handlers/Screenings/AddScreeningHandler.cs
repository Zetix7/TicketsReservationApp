using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;
using TicketsReservation.DataAccess.CQRS.Commands;
using TicketsReservation.DataAccess.CQRS.Commands.Screenings;

namespace TicketsReservation.ApplicationServices.API.Handlers.Screenings;

public class AddScreeningHandler : IRequestHandler<AddScreeningRequest, AddScreeningResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddScreeningHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddScreeningResponse> Handle(AddScreeningRequest request, CancellationToken cancellationToken)
    {
        var screening = _mapper.Map<DataAccess.Entities.Screening>(request);
        var command = new AddScreeningCommand { Parameter = screening };
        screening = await _commandExecutor.Execute(command);
        var domainScreening = _mapper.Map<Screening>(screening);
        return new AddScreeningResponse { Data = domainScreening };
    }
}
