using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Clients;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetClientsHandler : IRequestHandler<GetClientsRequest, GetClientsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetClientsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetClientsQuery();
        var clients = await _queryExecutor.Execute(query);
        var mappedClients = _mapper.Map<List<Client>>(clients);
        var response = new GetClientsResponse() { Data = mappedClients };
        return response;
    }
}
