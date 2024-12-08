using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Reservations;

namespace TicketsReservation.ApplicationServices.API.Handlers.Reservations;

public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdRequest, GetReservationByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetReservationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetReservationByIdResponse> Handle(GetReservationByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetReservationByIdQuery { Id = request.Id };
        var reservation = await _queryExecutor.Execute(query);
        if (reservation == null)
        {
            reservation = new DataAccess.Entities.Reservation();
        }

        var mappedReservation = _mapper.Map<Reservation>(reservation);
        var response = new GetReservationByIdResponse { Data = mappedReservation };
        return response;
    }
}
