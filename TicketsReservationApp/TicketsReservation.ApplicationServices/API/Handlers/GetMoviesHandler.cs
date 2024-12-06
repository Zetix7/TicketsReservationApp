using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Movies;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetMoviesHandler : IRequestHandler<GetMoviesRequest, GetMoviesResponse>
{
    private readonly IRepository<DataAccess.Entities.Movie> _repository;

    public GetMoviesHandler(IRepository<DataAccess.Entities.Movie> repository)
    {
        _repository = repository;
    }

    public Task<GetMoviesResponse> Handle(GetMoviesRequest request, CancellationToken cancellationToken)
    {
        var movies = _repository.GetAll();
        var domainMovies = movies.Select(x => new Movie
        {
            Title = x.Title,
            Durtion = x.Durtion,
        }).ToList();

        var response = new GetMoviesResponse { Data = domainMovies };
        return Task.FromResult(response);
    }
}
