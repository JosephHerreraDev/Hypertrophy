using Hypertrophy.Domain.Exercise;

namespace Hypertrophy.Infrastructure.Repositories;

internal sealed class ExerciseRepository : Repository<ExerciseEntity, ExerciseId>, IExerciseRepository
{
    public ExerciseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
