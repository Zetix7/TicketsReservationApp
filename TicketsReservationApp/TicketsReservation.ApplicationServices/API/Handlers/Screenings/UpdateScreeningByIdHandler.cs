using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;
using TicketsReservation.DataAccess.CQRS.Commands;
using TicketsReservation.DataAccess.CQRS.Commands.Screenings;

namespace TicketsReservation.ApplicationServices.API.Handlers.Screenings;

public class UpdateScreeningByIdHandler : IRequestHandler<UpdateScreeningByIdRequest, UpdateScreeningByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateScreeningByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateScreeningByIdResponse> Handle(UpdateScreeningByIdRequest request, CancellationToken cancellationToken)
    {
        var screening = _mapper.Map<DataAccess.Entities.Screening>(request);
        var command = new UpdateScreeningByIdCommand { Parameter = screening };
        screening = await _commandExecutor.Execute(command);
        var domainScreening = _mapper.Map<Screening>(screening);
        return new UpdateScreeningByIdResponse { Data = domainScreening };
    }
}
