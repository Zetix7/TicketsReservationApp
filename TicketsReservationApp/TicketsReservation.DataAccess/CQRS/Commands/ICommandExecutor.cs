namespace TicketsReservation.DataAccess.CQRS.Commands;

public interface ICommandExecutor
{
    Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command);
}
