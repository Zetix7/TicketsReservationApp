using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Screenings;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetScreeningByIdHandler : IRequestHandler<GetScreeningByIdRequest, GetScreeningByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetScreeningByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetScreeningByIdResponse> Handle(GetScreeningByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetScreeningByIdQuery { Id = request.Id };
        var screening = await _queryExecutor.Execute(query);
        if(screening == null)
        {
            screening = new DataAccess.Entities.Screening();
        }

        var mappedScreening = _mapper.Map<Screening>(screening);
        var response = new GetScreeningByIdResponse { Data = mappedScreening };
        return response;
    }
}
