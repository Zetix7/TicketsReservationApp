using AutoMapper;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Movies;

namespace TicketsReservation.ApplicationServices.Mappings;

public class MoviesProfile : Profile
{
    public MoviesProfile()
    {
        CreateMap<AddMovieRequest, DataAccess.Entities.Movie>()
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.Duration, y => y.MapFrom(z => z.Duration));

        CreateMap<DataAccess.Entities.Movie, Movie>()
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.Durtaion, y => y.MapFrom(z => z.Duration));
    }
}
