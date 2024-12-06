using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Client> _repository;

    public GetClientByIdHandler(IRepository<DataAccess.Entities.Client> repository)
    {
        _repository = repository;
    }

    public Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
    {
        var client = _repository.GetById(request.Id);
        if (client == null)
        {
            client = new DataAccess.Entities.Client();
        }

        var domainClient = new Client { FirstName = client?.FirstName, LastName = client?.LastName };
        var response = new GetClientByIdResponse() { Data = domainClient };
        return Task.FromResult(response);
    }
}
