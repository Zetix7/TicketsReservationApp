using AutoMapper;
using MediatR;
using System.Net.Sockets;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.DataAccess.CQRS.Commands;
using TicketsReservation.DataAccess.CQRS.Commands.Clients;

namespace TicketsReservation.ApplicationServices.API.Handlers.Clients;

public class AddClientHandler : IRequestHandler<AddClientRequest, AddClientResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddClientHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddClientResponse> Handle(AddClientRequest request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<DataAccess.Entities.Client>(request);
        var command = new AddClientCommand { Parameter = client };
        client = await _commandExecutor.Execute(command);
        var domainClient = _mapper.Map<Client>(client);
        return new AddClientResponse { Data = domainClient };
    }
}
