using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetClientsHandler : IRequestHandler<GetClientsRequest, GetClientsResponse>
{
    private readonly IRepository<DataAccess.Entities.Client> _repository;
    private readonly IMapper _mapper;

    public GetClientsHandler(IRepository<DataAccess.Entities.Client> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
    {
        var clients = _repository.GetAll();
        var mappedClients = _mapper.Map<List<Client>>(clients);
        var response = new GetClientsResponse() { Data = mappedClients };
        return Task.FromResult(response);
    }
}
