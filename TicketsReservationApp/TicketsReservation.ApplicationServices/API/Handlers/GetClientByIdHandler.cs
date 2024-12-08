using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetClientByIdHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Client> _repository;
    private readonly IMapper _mapper;

    public GetClientByIdHandler(IRepository<DataAccess.Entities.Client> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
    {
        var client = await _repository.GetById(request.Id)!;
        if (client == null)
        {
            client = new DataAccess.Entities.Client();
        }

        var mappedClient = _mapper.Map<Client>(client);
        var response = new GetClientByIdResponse() { Data = mappedClient };
        return response;
    }
}
