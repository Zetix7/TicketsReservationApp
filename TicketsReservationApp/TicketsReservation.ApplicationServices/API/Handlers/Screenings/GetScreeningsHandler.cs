using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Screenings;

namespace TicketsReservation.ApplicationServices.API.Handlers.Screenings;

public class GetScreeningsHandler : IRequestHandler<GetScreeningsRequest, GetScreeningsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetScreeningsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetScreeningsResponse> Handle(GetScreeningsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetScreeningsQuery();
        var screenings = await _queryExecutor.Execute(query);
        var mappedScreenings = _mapper.Map<List<Screening>>(screenings);
        var response = new GetScreeningsResponse { Data = mappedScreenings };
        return response;
    }
}
