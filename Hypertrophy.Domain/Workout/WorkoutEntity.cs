using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Domain.Set;
using Hypertrophy.Domain.Shared;

namespace Hypertrophy.Domain.Workout;

public class WorkoutEntity : Entity<WorkoutId>
{
    public WorkoutEntity() { }

    public WorkoutEntity(
        WorkoutId id,
        DateTime startedAt,
        DateTime? finishedAt,
        eWorkoutType type,
        List<SetEntity> sets
    ) : base(id)
    {
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        Type = type;
        Sets = sets;
    }
    public DateTime StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public eWorkoutType Type { get; private set; }
    public List<SetEntity>? Sets { get; private set; }
    public TimeSpan? Duration =>
        FinishedAt.HasValue
            ? FinishedAt - StartedAt
            : null;
}
