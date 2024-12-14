using AutoMapper;
using TicketsReservation.ApplicationServices.API.Domain.Clients;
using TicketsReservation.ApplicationServices.API.Domain.Models;

namespace TicketsReservation.ApplicationServices.Mappings;

public class ClientsProfile : Profile
{
    public ClientsProfile()
    {
        CreateMap<UpdateClientByIdRequest, DataAccess.Entities.Client>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));

        CreateMap<AddClientRequest, DataAccess.Entities.Client>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));

        CreateMap<DataAccess.Entities.Client, Client>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
    }
}
