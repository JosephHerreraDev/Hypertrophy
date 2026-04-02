using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Domain.Shared;

namespace Hypertrophy.Domain.Exercise;

public sealed class ExerciseEntity : Entity<ExerciseId>
{
    public ExerciseEntity() { }

    public ExerciseEntity(
        ExerciseId id,
        string name,
        List<MuscleGroupEntity> muscleGroups,
        List<Media> exerciseMedia,
        eEquipment equipment
    ) : base(id)
    {
        Name = name;
        MuscleGroups = muscleGroups;
        ExerciseMedia = exerciseMedia;
        Equipment = equipment;
    }
    public string? Name { get; private set; }
    public List<MuscleGroupEntity>? MuscleGroups { get; private set; }
    public eEquipment? Equipment { get; private set; }
    public List<Media>? ExerciseMedia { get; private set; }

    public static Result<ExerciseEntity> Create(
        string name,
        List<MuscleGroupEntity> muscleGroups,
        List<Media> exerciseMedia,
        eEquipment equipment
    )
    {
        var exercise = new ExerciseEntity(
            ExerciseId.New(),
            name,
            muscleGroups,
            exerciseMedia,
            equipment);

        return exercise;
    }
}
