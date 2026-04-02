using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Domain.MuscleGroup;
using Hypertrophy.Domain.Shared;

namespace Hypertrophy.Domain.Exercise;

public class MuscleGroupEntity : Entity<MuscleGroupId>
{
    public MuscleGroupEntity()
    {

    }

    public Guid ExerciseId { get; set; }
    public ExerciseEntity Exercise { get; set; } = default!;
    public eMuscleGroup MuscleGroup { get; set; } = default!;
    public eMuscleGroupRole? Role { get; set; }
}