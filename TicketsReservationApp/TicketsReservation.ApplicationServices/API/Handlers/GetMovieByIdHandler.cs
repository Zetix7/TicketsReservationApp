using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Movies;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdRequest, GetMovieByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Movie> _repository;

    public GetMovieByIdHandler(IRepository<DataAccess.Entities.Movie> repository)
    {
        _repository = repository;
    }

    public Task<GetMovieByIdResponse> Handle(GetMovieByIdRequest request, CancellationToken cancellationToken)
    {
        var movie = _repository.GetById(request.Id);
        if (movie == null)
        {
            movie = new DataAccess.Entities.Movie();
        }

        var domainMovie = new Movie { Title = movie.Title, Durtion = movie.Durtion };
        var response = new GetMovieByIdResponse { Data = domainMovie };
        return Task.FromResult(response);
    }
}
