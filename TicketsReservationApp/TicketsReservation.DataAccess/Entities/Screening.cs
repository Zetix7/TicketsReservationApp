using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Screening : EntityBase
{
    [Required]
    public int MovieId { get; set; }
    
    [Required]
    public int RoomId { get; set; }
    
    [Required]
    public DateTime DisplayDate { get; set; }
}
