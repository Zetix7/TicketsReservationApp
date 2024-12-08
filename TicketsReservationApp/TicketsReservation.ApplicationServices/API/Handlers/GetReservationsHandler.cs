using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
{
    private readonly IRepository<DataAccess.Entities.Reservation> _repository;
    private readonly IMapper _mapper;

    public GetReservationsHandler(IRepository<DataAccess.Entities.Reservation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
    {
        var reservations = await _repository.GetAll();
        var domainReservations = _mapper.Map<List<Reservation>>(reservations);
        var response = new GetReservationsResponse { Data = domainReservations };
        return response;
    }
}
