using Hypertrophy.Domain.Abstractions;

namespace Hypertrophy.Domain.Routine;

public class RoutineErrors
{
    public static Error RoutineDoesNotExist = new(nameof(RoutineDoesNotExist));
    public static Error RoutineDayDoesNotExist = new(nameof(RoutineDayDoesNotExist));
}
