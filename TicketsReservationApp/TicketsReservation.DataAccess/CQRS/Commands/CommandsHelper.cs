namespace TicketsReservation.DataAccess.CQRS.Commands;

public static class CommandsHelper
{
    public static bool IsValidStringValue(string newValue, string entityValue)
    {
        return !string.IsNullOrEmpty(newValue) && !string.IsNullOrWhiteSpace(newValue) && entityValue != newValue;
    }
}
