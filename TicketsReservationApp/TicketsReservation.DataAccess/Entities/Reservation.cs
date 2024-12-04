using System.ComponentModel.DataAnnotations;

namespace TicketsReservation.DataAccess.Entities;

public class Reservation : EntityBase
{
    public int ClientId { get; set; }

    public Client? Client { get; set; }

    public int ScreeningId { get; set; }

    public Screening? Screening { get; set; }

    [Required]
    public char RowLetterSeatPlace { get; set; }
    
    [Required]
    public int NumberSeatPlace { get; set; }

    [Required]
    public bool IsPremiumSeatPlace { get; set; }
    
    [Required]
    public decimal Price { get; set; }
}
