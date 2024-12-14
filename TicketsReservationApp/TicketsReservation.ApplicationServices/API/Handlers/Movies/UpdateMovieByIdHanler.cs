using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Movies;
using TicketsReservation.DataAccess.CQRS.Commands;
using TicketsReservation.DataAccess.CQRS.Commands.Movies;

namespace TicketsReservation.ApplicationServices.API.Handlers.Movies;

public class UpdateMovieByIdHanler : IRequestHandler<UpdateMovieByIdRequest, UpdateMovieByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateMovieByIdHanler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateMovieByIdResponse> Handle(UpdateMovieByIdRequest request, CancellationToken cancellationToken)
    {
        var movie = _mapper.Map<DataAccess.Entities.Movie>(request);
        var command = new UpdateMovieByIdCommand { Parameter = movie };
        movie = await _commandExecutor.Execute(command);
        var domainMovie = _mapper.Map<Movie>(movie);
        return new UpdateMovieByIdResponse { Data = domainMovie };
    }
}
