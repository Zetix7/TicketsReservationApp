using AutoMapper;
using TicketsReservation.ApplicationServices.API.Domain.Models;

namespace TicketsReservation.ApplicationServices.Mappings;

public class ScreeningsProfile : Profile
{
    public ScreeningsProfile()
    {
        CreateMap<DataAccess.Entities.Screening, Screening>()
            .ForMember(x => x.MovieId, y => y.MapFrom(z => z.MovieId))
            .ForMember(x => x.Movie, y => y.MapFrom(z => z.Movie))
            .ForMember(x => x.Room, y => y.MapFrom(z => z.Room))
            .ForMember(x => x.RoomId, y => y.MapFrom(z => z.RoomId))
            .ForMember(x => x.Reservations, y => y.MapFrom(z => z.Reservations))
            .ForMember(x => x.DisplayDate, y => y.MapFrom(z => z.DisplayDate));
    }
}
