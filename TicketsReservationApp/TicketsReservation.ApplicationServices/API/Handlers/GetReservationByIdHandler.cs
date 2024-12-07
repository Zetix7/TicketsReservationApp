using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdRequest, GetReservationByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Reservation> _repository;
    private readonly IMapper _mapper;

    public GetReservationByIdHandler(IRepository<DataAccess.Entities.Reservation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<GetReservationByIdResponse> Handle(GetReservationByIdRequest request, CancellationToken cancellationToken)
    {
        var reservation = _repository.GetById(request.Id);
        if (reservation == null)
        {
            reservation = new DataAccess.Entities.Reservation();
        }

        var mappedReservation = _mapper.Map<Reservation>(reservation);
        var response = new GetReservationByIdResponse { Data = mappedReservation };
        return Task.FromResult(response);
    }
}
