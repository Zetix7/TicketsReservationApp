using AutoMapper;
using TicketsReservation.ApplicationServices.API.Domain.Models;

namespace TicketsReservation.ApplicationServices.Mappings;

public class MoviesProfile : Profile
{
    public MoviesProfile()
    {
        CreateMap<DataAccess.Entities.Movie, Movie>()
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.Durtion, y => y.MapFrom(z => z.Durtion));
    }
}
