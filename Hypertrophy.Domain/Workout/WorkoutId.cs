namespace Hypertrophy.Domain.Workout;

public record WorkoutId(Guid Value)
{
    public static WorkoutId New() => new(Guid.NewGuid());
}
