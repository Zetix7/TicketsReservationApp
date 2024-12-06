using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetClientsHandler : IRequestHandler<GetClientsRequest, GetClientsResponse>
{
    private readonly IRepository<DataAccess.Entities.Client> _repository;

    public GetClientsHandler(IRepository<DataAccess.Entities.Client> repository)
    {
        _repository = repository;
    }

    public Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
    {
        var clients = _repository.GetAll();
        var domainClients = clients.Select(x => new Client
        {
            FirstName = x.FirstName,
            LastName = x.LastName
        }).ToList();

        var response = new GetClientsResponse() { Data = domainClients };
        return Task.FromResult(response);
    }
}
