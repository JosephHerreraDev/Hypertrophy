using Hypertrophy.Domain.Abstractions;

namespace Hypertrophy.Domain.Exercise;

public static class ExerciseErrors
{
    public static Error ExerciseDoesNotExist = new(nameof(ExerciseDoesNotExist));
    public static Error ExerciseCouldNotBeCreated = new(nameof(ExerciseCouldNotBeCreated));
}
