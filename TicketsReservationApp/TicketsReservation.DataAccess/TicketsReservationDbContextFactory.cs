using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TicketsReservation.DataAccess;

public class TicketsReservationDbContextFactory : IDesignTimeDbContextFactory<TicketsReservationDbContext>
{
    public TicketsReservationDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<TicketsReservationDbContext>();
        optionBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TicketsReservationStorage;Integrated Security=True;Trust Server Certificate=True");
        return new TicketsReservationDbContext(optionBuilder.Options);
    }
}
