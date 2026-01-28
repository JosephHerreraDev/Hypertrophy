using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Domain.Exercise;

namespace Hypertrophy.Domain.Routine;

public sealed class RoutineDayEntity : Entity<RoutineDayId>
{
    public RoutineDayEntity() { }

    public RoutineDayEntity(RoutineDayId id, string name, eRoutineDayType dayType, List<ExerciseId> exerciseIds) : base(id)
    {
        Name = name;           // "Push A", "Pull", "Legs B"
        DayType = dayType;
        ExerciseIds = exerciseIds;
    }

    public string Name { get; private set; } = default!;
    public eRoutineDayType DayType { get; private set; }
    public List<ExerciseId>? ExerciseIds { get; private set; }
}
