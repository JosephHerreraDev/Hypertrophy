using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Domain.Shared;

namespace Hypertrophy.Domain.Exercise;

public sealed class ExerciseEntity : Entity<ExerciseId>
{
    public ExerciseEntity() { }

    public ExerciseEntity(
        ExerciseId id,
        string name,
        List<eMuscleGroup> primaryMuscleGroup,
        List<eMuscleGroup> secondaryMuscleGroup,
        List<Media> exerciseMedia,
        eEquipment equipment
    ) : base(id)
    {
        Name = name;
        PrimaryMuscleGroup = primaryMuscleGroup;
        SecondaryMuscleGroup = secondaryMuscleGroup;
        ExerciseMedia = exerciseMedia;
        Equipment = equipment;
    }
    public string? Name { get; private set; }
    public List<eMuscleGroup>? PrimaryMuscleGroup { get; private set; }
    public List<eMuscleGroup>? SecondaryMuscleGroup { get; private set; }
    public eEquipment? Equipment { get; private set; }
    public List<Media>? ExerciseMedia { get; private set; }
}
