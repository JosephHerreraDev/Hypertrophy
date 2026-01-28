namespace Hypertrophy.Domain.Routine;

public record RoutineId(Guid Value)
{
    public static RoutineId New() => new(Guid.NewGuid());
}
