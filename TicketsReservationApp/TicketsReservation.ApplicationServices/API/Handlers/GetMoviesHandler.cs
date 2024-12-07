using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Movies;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetMoviesHandler : IRequestHandler<GetMoviesRequest, GetMoviesResponse>
{
    private readonly IRepository<DataAccess.Entities.Movie> _repository;
    private readonly IMapper _mapper;

    public GetMoviesHandler(IRepository<DataAccess.Entities.Movie> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<GetMoviesResponse> Handle(GetMoviesRequest request, CancellationToken cancellationToken)
    {
        var movies = _repository.GetAll();
        var mappedMovies = _mapper.Map<List<Movie>>(movies);
        var response = new GetMoviesResponse { Data = mappedMovies };
        return Task.FromResult(response);
    }
}
