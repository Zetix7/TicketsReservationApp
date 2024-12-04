using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Room : EntityBase
{
    public List<Screening>? Screenings { get; set; }

    [Required]
    public bool IsScreen3d { get; set; }
    
    [Required]
    public int PremiumSeatsCount { get; set; }

    [Required]
    public int RegularSeatsCount { get; set; }
}
