using AutoMapper;
using TicketsReservation.ApplicationServices.API.Domain.Models;
using TicketsReservation.ApplicationServices.API.Domain.Rooms;

namespace TicketsReservation.ApplicationServices.Mappings;

public class RoomsProfile : Profile
{
    public RoomsProfile()
    {
        CreateMap<UpdateRoomByIdRequest, DataAccess.Entities.Room>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.IsScreen3d, y => y.MapFrom(z => z.IsScreen3d))
            .ForMember(x => x.PremiumSeatsCount, y => y.MapFrom(z => z.PremiumSeatsCount))
            .ForMember(x => x.RegularSeatsCount, y => y.MapFrom(z => z.RegularSeatsCount));

        CreateMap<AddRoomRequest, DataAccess.Entities.Room>()
            .ForMember(x => x.IsScreen3d, y => y.MapFrom(z => z.IsScreen3d))
            .ForMember(x => x.PremiumSeatsCount, y => y.MapFrom(z => z.PremiumSeatsCount))
            .ForMember(x => x.RegularSeatsCount, y => y.MapFrom(z => z.RegularSeatsCount));

        CreateMap<DataAccess.Entities.Room, Room>()
            .ForMember(x => x.Screenings, y => y.MapFrom(z => z.Screenings))
            .ForMember(x => x.IsScreen3d, y => y.MapFrom(z => z.IsScreen3d))
            .ForMember(x => x.PremiumSeatsCount, y => y.MapFrom(z => z.PremiumSeatsCount))
            .ForMember(x => x.RegularSeatsCount, y => y.MapFrom(z => z.RegularSeatsCount));
    }
}
