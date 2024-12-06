using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, GetReservationsResponse>
{
    private readonly IRepository<DataAccess.Entities.Reservation> _repository;

    public GetReservationsHandler(IRepository<DataAccess.Entities.Reservation> repository)
    {
        _repository = repository;
    }

    public Task<GetReservationsResponse> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
    {
        var reservations = _repository.GetAll();
        var domainReservations = reservations.Select(x => new Reservation
        {
            ClientId = x.ClientId,
            Client = new Client(),
            ScreeningId = x.ScreeningId,
            Screening = new Screening(),
            RowLetterSeatPlace = x.RowLetterSeatPlace,
            NumberSeatPlace = x.NumberSeatPlace,
            IsPremiumSeatPlace = x.IsPremiumSeatPlace,
            Price = x.Price,
        }).ToList();

        var response = new GetReservationsResponse { Data = domainReservations };
        return Task.FromResult(response);
    }
}
