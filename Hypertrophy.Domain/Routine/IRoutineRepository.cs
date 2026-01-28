namespace Hypertrophy.Domain.Routine;

public interface IRoutineRepository
{
    Task<RoutineEntity?> GetByIdAsync(RoutineId id, CancellationToken cancellationToken = default);
    void Add(RoutineEntity workoutEntity);
    void Update(RoutineEntity workoutEntity);
    void Delete(RoutineEntity workoutEntit);

    Task<RoutineDayEntity?> GetByIdAsync(RoutineDayId id, CancellationToken cancellationToken = default);
    void Add(RoutineDayEntity workoutEntity);
    void Update(RoutineDayEntity workoutEntity);
    void Delete(RoutineDayEntity workoutEntit);
}
