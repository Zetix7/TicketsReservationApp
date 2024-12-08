namespace TicketsReservation.DataAccess.CQRS.Commands;

public class CommandExecutor : ICommandExecutor
{
    private readonly TicketsReservationDbContext _context;

    public CommandExecutor(TicketsReservationDbContext context)
    {
        _context = context;
    }

    public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
    {
        return command.Execute(_context);
    }
}
