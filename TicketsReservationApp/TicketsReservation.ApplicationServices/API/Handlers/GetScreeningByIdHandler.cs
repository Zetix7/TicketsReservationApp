using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetScreeningByIdHandler : IRequestHandler<GetScreeningByIdRequest, GetScreeningByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Screening> _repository;

    public GetScreeningByIdHandler(IRepository<DataAccess.Entities.Screening> repository)
    {
        _repository = repository;
    }

    public Task<GetScreeningByIdResponse> Handle(GetScreeningByIdRequest request, CancellationToken cancellationToken)
    {
        var screening = _repository.GetById(request.Id);
        if(screening == null)
        {
            screening = new DataAccess.Entities.Screening();
        }

        var domainScreening = new Screening
        {
            MovieId = screening.MovieId,
            Movie = new Movie(),
            RoomId = screening.RoomId,
            Room = new Room(),
            Reservations = [],
            DisplayDate = screening.DisplayDate,
        };
        var response = new GetScreeningByIdResponse { Data = domainScreening };
        return Task.FromResult(response);
    }
}
