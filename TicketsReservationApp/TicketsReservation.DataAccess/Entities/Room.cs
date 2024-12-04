using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Room : EntityBase
{
    [Required]
    public string? RoomType { get; set; }
    
    [Required]
    public int PremiumSeatsCount { get; set; }

    [Required]
    public int RegularSeatsCount { get; set; }
}
