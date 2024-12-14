using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.DataAccess.CQRS.Commands;
using TicketsReservation.DataAccess.CQRS.Commands.Clients;

namespace TicketsReservation.ApplicationServices.API.Handlers.Clients;

public class UpdateClientByIdHandler : IRequestHandler<UpdateClientByIdRequest, UpdateClientByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateClientByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateClientByIdResponse> Handle(UpdateClientByIdRequest request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<DataAccess.Entities.Client>(request);
        var command = new UpdateClientByIdCommand { Parameter = client };
        client = await _commandExecutor.Execute(command);
        var domainClient = _mapper.Map<Client>(client);
        return new UpdateClientByIdResponse { Data = domainClient };
    }
}
