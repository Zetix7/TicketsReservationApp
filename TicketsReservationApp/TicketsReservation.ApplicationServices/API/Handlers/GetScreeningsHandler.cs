using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetScreeningsHandler : IRequestHandler<GetScreeningsRequest, GetScreeningsResponse>
{
    private readonly IRepository<DataAccess.Entities.Screening> _repository;
    private readonly IMapper _mapper;

    public GetScreeningsHandler(IRepository<DataAccess.Entities.Screening> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<GetScreeningsResponse> Handle(GetScreeningsRequest request, CancellationToken cancellationToken)
    {
        var screenings = _repository.GetAll();
        var mappedScreenings = _mapper.Map<List<Screening>>(screenings);
        var response = new GetScreeningsResponse { Data = mappedScreenings };
        return Task.FromResult(response);
    }
}
