using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetScreeningsHandler : IRequestHandler<GetScreeningsRequest, GetScreeningsResponse>
{
    private readonly IRepository<DataAccess.Entities.Screening> _repository;

    public GetScreeningsHandler(IRepository<DataAccess.Entities.Screening> repository)
    {
        _repository = repository;
    }

    public Task<GetScreeningsResponse> Handle(GetScreeningsRequest request, CancellationToken cancellationToken)
    {
        var screenings = _repository.GetAll();
        var domainScreenings = screenings.Select(x => new Screening
        {
            MovieId = x.MovieId,
            Movie = new Movie(),
            RoomId = x.RoomId,
            Room = new Room(),
            Reservations = [],
            DisplayDate = x.DisplayDate,
        }).ToList();

        var response = new GetScreeningsResponse { Data = domainScreenings };
        return Task.FromResult(response);
    }
}
