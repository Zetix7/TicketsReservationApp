using AutoMapper;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Screenings;

namespace TicketsReservation.ApplicationServices.Mappings;

public class ScreeningsProfile : Profile
{
    public ScreeningsProfile()
    {
        CreateMap<UpdateScreeningByIdRequest, DataAccess.Entities.Screening>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.MovieId, y => y.MapFrom(z => z.MovieId))
            .ForMember(x => x.RoomId, y => y.MapFrom(z => z.RoomId))
            .ForMember(x => x.DisplayDate, y => y.MapFrom(z => z.DisplayDate));

        CreateMap<AddScreeningRequest, DataAccess.Entities.Screening>()
            .ForMember(x => x.MovieId, y => y.MapFrom(z => z.MovieId))
            .ForMember(x => x.RoomId, y => y.MapFrom(z => z.RoomId))
            .ForMember(x => x.DisplayDate, y => y.MapFrom(z => z.DisplayDate));

        CreateMap<DataAccess.Entities.Screening, Screening>()
            .ForMember(x => x.MovieId, y => y.MapFrom(z => z.MovieId))
            .ForMember(x => x.Movie, y => y.MapFrom(z => z.Movie))
            .ForMember(x => x.RoomId, y => y.MapFrom(z => z.RoomId))
            .ForMember(x => x.Room, y => y.MapFrom(z => z.Room))
            .ForMember(x => x.Reservations, y => y.MapFrom(z => z.Reservations))
            .ForMember(x => x.DisplayDate, y => y.MapFrom(z => z.DisplayDate));
    }
}
