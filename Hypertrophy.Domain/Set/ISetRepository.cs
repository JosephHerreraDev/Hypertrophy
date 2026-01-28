namespace Hypertrophy.Domain.Set;

public interface ISetRepository
{
    Task<SetEntity?> GetByIdAsync(SetId id, CancellationToken cancellationToken = default);
    void Add(SetEntity workoutEntity);
    void Update(SetEntity workoutEntity);
    void Delete(SetEntity workoutEntit);
}
