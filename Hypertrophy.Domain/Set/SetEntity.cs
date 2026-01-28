using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Domain.Exercise;
using Hypertrophy.Domain.Shared;

namespace Hypertrophy.Domain.Set;

public sealed class SetEntity : Entity<SetId>
{
    public SetEntity() { }

    public SetEntity(
        SetId id,
        ExerciseEntity exercise,
        int reps,
        Weight weight) : base(id)
    {
        Exercise = exercise;
        Reps = reps;
        Weight = weight;
    }

    public ExerciseEntity? Exercise { get; private set; }
    public int? Reps { get; private set; }
    public Weight Weight { get; private set; }
}
