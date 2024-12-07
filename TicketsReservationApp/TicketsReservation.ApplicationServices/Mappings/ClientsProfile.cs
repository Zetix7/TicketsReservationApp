using AutoMapper;
using TicketsReservation.ApplicationServices.API.Domain.Models;

namespace TicketsReservation.ApplicationServices.Mappings;

public class ClientsProfile : Profile
{
    public ClientsProfile()
    {
        CreateMap<DataAccess.Entities.Client, Client>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
    }
}
