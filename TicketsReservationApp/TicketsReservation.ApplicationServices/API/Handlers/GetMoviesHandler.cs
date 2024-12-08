using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Movies;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.CQRS.Queries.Movies;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetMoviesHandler : IRequestHandler<GetMoviesRequest, GetMoviesResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetMoviesHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetMoviesResponse> Handle(GetMoviesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetMoviesQuery();
        var movies = await _queryExecutor.Execute(query);
        var mappedMovies = _mapper.Map<List<Movie>>(movies);
        var response = new GetMoviesResponse { Data = mappedMovies };
        return response;
    }
}
