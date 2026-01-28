using Hypertrophy.Domain.Abstractions;

namespace Hypertrophy.Domain.Workout;

public class WorkoutErrors
{
    public static Error WorkoutDoesNotExist = new(nameof(WorkoutDoesNotExist));
}
