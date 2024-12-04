using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Reservation : EntityBase
{

    [Required]
    public int ClientId { get; set; }

    [Required]
    public int ScreeningId { get; set; }

    [Required]
    public char RowLetterSeatPlace { get; set; }
    
    [Required]
    public int NumberSeatPlace { get; set; }

    [Required]
    public string? PlaceType { get; set; }
    
    [Required]
    public decimal Price { get; set; }
}
