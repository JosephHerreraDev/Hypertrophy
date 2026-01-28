namespace Hypertrophy.Domain.Exercise;

public interface IExerciseRepository
{
    Task<ExerciseEntity?> GetByIdAsync(ExerciseId id, CancellationToken cancellationToken = default);
    void Add(ExerciseEntity workoutEntity);
    void Update(ExerciseEntity workoutEntity);
    void Delete(ExerciseEntity workoutEntit);
}
