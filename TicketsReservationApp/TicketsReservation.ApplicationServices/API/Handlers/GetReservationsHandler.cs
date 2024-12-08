using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Reservations;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetReservationsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetReservationsQuery();
        var reservations = await _queryExecutor.Execute(query);
        var domainReservations = _mapper.Map<List<Reservation>>(reservations);
        var response = new GetReservationsResponse { Data = domainReservations };
        return response;
    }
}
