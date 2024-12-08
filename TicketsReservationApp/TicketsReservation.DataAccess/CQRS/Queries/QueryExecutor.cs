namespace TicketsReservation.DataAccess.CQRS.Queries;

public class QueryExecutor : IQueryExecutor
{
    private readonly TicketsReservationDbContext _context;

    public QueryExecutor(TicketsReservationDbContext context)
    {
        _context = context;
    }

    public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
    {
        return query.Execute(_context)!;
    }
}
