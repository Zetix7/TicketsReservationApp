using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Movies;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdRequest, GetMovieByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Movie> _repository;
    private readonly IMapper _mapper;

    public GetMovieByIdHandler(IRepository<DataAccess.Entities.Movie> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<GetMovieByIdResponse> Handle(GetMovieByIdRequest request, CancellationToken cancellationToken)
    {
        var movie = _repository.GetById(request.Id);
        if (movie == null)
        {
            movie = new DataAccess.Entities.Movie();
        }

        var mappedMovie = _mapper.Map<Movie>(movie);
        var response = new GetMovieByIdResponse { Data = mappedMovie };
        return Task.FromResult(response);
    }
}
