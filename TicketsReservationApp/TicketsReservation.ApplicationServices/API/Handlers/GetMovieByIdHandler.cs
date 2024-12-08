using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Movies;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Movies;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdRequest, GetMovieByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetMovieByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetMovieByIdResponse> Handle(GetMovieByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetMovieByIdQuery { Id = request.Id };
        var movie = await _queryExecutor.Execute(query);
        if (movie == null)
        {
            movie = new DataAccess.Entities.Movie();
        }

        var mappedMovie = _mapper.Map<Movie>(movie);
        var response = new GetMovieByIdResponse { Data = mappedMovie };
        return response;
    }
}
