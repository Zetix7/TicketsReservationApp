using Microsoft.EntityFrameworkCore;
using TicketsReservation.DataAccess.Entities;

namespace TicketsReservation.DataAccess;

public class TicketsReservationDbContext : DbContext
{
    public DbSet<Client>? Clients { get; set; }
    public DbSet<Movie>? Movies { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<Screening>? Screenings { get; set; }
    public DbSet<Reservation>? Reservations { get; set; }

    public TicketsReservationDbContext(DbContextOptions<TicketsReservationDbContext> options) : base(options)
    {
    }
}
