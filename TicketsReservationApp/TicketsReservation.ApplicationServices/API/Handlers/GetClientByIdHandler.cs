using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Clients;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetClientByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetClientByIdQuery() { Id = request.Id };
        var client = await _queryExecutor.Execute(query);
        if (client == null)
        {
            client = new DataAccess.Entities.Client();
        }

        var mappedClient = _mapper.Map<Client>(client);
        var response = new GetClientByIdResponse() { Data = mappedClient };
        return response;
    }
}
