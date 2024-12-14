using AutoMapper;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Reservations;

namespace TicketsReservation.ApplicationServices.Mappings;

public class ReservationsProfile : Profile
{
    public ReservationsProfile()
    {
        CreateMap<UpdateReservationByIdRequest, DataAccess.Entities.Reservation>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ClientId, y => y.MapFrom(z => z.ClientId))
            .ForMember(x => x.ScreeningId, y => y.MapFrom(z => z.ScreeningId))
            .ForMember(x => x.RowLetterSeatPlace, y => y.MapFrom(z => z.RowLetterSeatPlace))
            .ForMember(x => x.NumberSeatPlace, y => y.MapFrom(z => z.NumberSeatPlace))
            .ForMember(x => x.IsPremiumSeatPlace, y => y.MapFrom(z => z.IsPremiumSeatPlace))
            .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));

        CreateMap<AddReservationRequest, DataAccess.Entities.Reservation>()
            .ForMember(x => x.ClientId, y => y.MapFrom(z => z.ClientId))
            .ForMember(x => x.ScreeningId, y => y.MapFrom(z => z.ScreeningId))
            .ForMember(x => x.RowLetterSeatPlace, y => y.MapFrom(z => z.RowLetterSeatPlace))
            .ForMember(x => x.NumberSeatPlace, y => y.MapFrom(z => z.NumberSeatPlace))
            .ForMember(x => x.IsPremiumSeatPlace, y => y.MapFrom(z => z.IsPremiumSeatPlace))
            .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));

        CreateMap<DataAccess.Entities.Reservation, Reservation>()
            .ForMember(x=>x.ClientId, y => y.MapFrom(z=>z.ClientId))
            .ForMember(x=>x.Client, y => y.MapFrom(z=>z.Client))
            .ForMember(x=>x.ScreeningId, y => y.MapFrom(z=>z.ScreeningId))
            .ForMember(x=>x.Screening, y => y.MapFrom(z=>z.Screening))
            .ForMember(x=>x.RowLetterSeatPlace, y => y.MapFrom(z=>z.RowLetterSeatPlace))
            .ForMember(x=>x.NumberSeatPlace, y => y.MapFrom(z=>z.NumberSeatPlace))
            .ForMember(x=>x.IsPremiumSeatPlace, y => y.MapFrom(z=>z.IsPremiumSeatPlace))
            .ForMember(x=>x.Price, y => y.MapFrom(z=>z.Price));
    }
}
