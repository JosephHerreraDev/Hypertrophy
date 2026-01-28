namespace Hypertrophy.Domain.Routine;

public record RoutineDayId(Guid Value)
{
    public static RoutineDayId New() => new(Guid.NewGuid());
}
