namespace Hypertrophy.Domain.Exercise;

public record ExerciseId(Guid Value)
{
    public static ExerciseId New() => new(Guid.NewGuid());
}
