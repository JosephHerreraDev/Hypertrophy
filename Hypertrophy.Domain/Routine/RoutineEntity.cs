using Hypertrophy.Domain.Abstractions;

namespace Hypertrophy.Domain.Routine;

public sealed class RoutineEntity : Entity<RoutineId>
{
    public RoutineEntity() { }

    public RoutineEntity(RoutineId id, string name, eRoutineType type, List<RoutineDayEntity> days) : base(id)
    {
        Name = name;
        Type = type;
        Days = days;
    }

    public string? Name { get; private set; }
    public eRoutineType? Type { get; private set; }     // e.g. PPL, Upper/Lower
    public List<RoutineDayEntity>? Days { get; private set; }
}

