using AutoMapper;
using MediatR;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.ApplicationServices.API.Handlers;

public class GetScreeningByIdHandler : IRequestHandler<GetScreeningByIdRequest, GetScreeningByIdResponse>
{
    private readonly IRepository<DataAccess.Entities.Screening> _repository;
    private readonly IMapper _mapper;

    public GetScreeningByIdHandler(IRepository<DataAccess.Entities.Screening> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<GetScreeningByIdResponse> Handle(GetScreeningByIdRequest request, CancellationToken cancellationToken)
    {
        var screening = _repository.GetById(request.Id);
        if(screening == null)
        {
            screening = new DataAccess.Entities.Screening();
        }

        var mappedScreening = _mapper.Map<Screening>(screening);
        var response = new GetScreeningByIdResponse { Data = mappedScreening };
        return Task.FromResult(response);
    }
}
