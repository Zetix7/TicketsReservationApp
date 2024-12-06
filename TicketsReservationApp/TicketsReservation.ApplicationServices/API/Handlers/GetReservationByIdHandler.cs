using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdRequest, GetReservationByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Reservation> _repository;

    public GetReservationByIdHandler(IRepository<DataAccess.Entities.Reservation> repository)
    {
        _repository = repository;
    }

    public Task<GetReservationByIdResponse> Handle(GetReservationByIdRequest request, CancellationToken cancellationToken)
    {
        var reservation = _repository.GetById(request.Id);
        if (reservation == null)
        {
            reservation = new DataAccess.Entities.Reservation();
        }

        var domainReservation = new Reservation
        {
            ClientId = reservation.ClientId,
            Client = new Client(),
            ScreeningId = reservation.ScreeningId,
            Screening = new Screening(),
            RowLetterSeatPlace = reservation.RowLetterSeatPlace,
            NumberSeatPlace = reservation.NumberSeatPlace,
            IsPremiumSeatPlace = reservation.IsPremiumSeatPlace,
            Price = reservation.Price,
        };
        var response = new GetReservationByIdResponse { Data = domainReservation };
        return Task.FromResult(response);
    }
}
