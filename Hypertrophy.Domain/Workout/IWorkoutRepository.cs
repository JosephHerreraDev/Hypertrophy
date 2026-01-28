namespace Hypertrophy.Domain.Workout;

public interface IWorkoutRepository
{
    Task<WorkoutEntity?> GetByIdAsync(WorkoutId id, CancellationToken cancellationToken = default);
    void Add(WorkoutEntity workoutEntity);
    void Update(WorkoutEntity workoutEntity);
    void Delete(WorkoutEntity workoutEntit);
}
