using Hypertrophy.Application.Abstractions.Clock;
using Hypertrophy.Application.Abstractions.Messaging;
using Hypertrophy.Domain.Abstractions;
using Hypertrophy.Domain.Exercise;
using Hypertrophy.Domain.Shared;

namespace Hypertrophy.Application.Exercise.CreateExercise;

public class CreateExerciseCommandHandler : ICommandHandler<CreateExerciseCommand, Guid>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public CreateExerciseCommandHandler(
        IExerciseRepository exerciseRepository,
        IDateTimeProvider dateTimeProvider,
        IUnitOfWork unitOfWork)
    {
        _exerciseRepository = exerciseRepository;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateExerciseCommand request,
        CancellationToken ct)
    {
        var mediaList = new List<Media>()
        {
            new Media(eMediaKind.Image, new Uri(""), "", "", 0, 0, new TimeSpan())
        };

        var primaryMuscleGroup = new List<eMuscleGroup>();

        var secondaryMuscleGroup = new List<eMuscleGroup>();

        var result = ExerciseEntity.Create(
            request.Name,
            primaryMuscleGroup,
            secondaryMuscleGroup,
            mediaList,
            request.Equipment
        );

        if (result.IsSuccess)
        {
            var exercise = result.Value;

            try
            {
                _exerciseRepository.Add(exercise);
                await _unitOfWork.SaveChangesAsync(ct);
                return Result.Success<Guid>(exercise.Id!.Value);
            }
            catch (System.Exception)
            {
                return Result.Failure<Guid>(ExerciseErrors.ExerciseCouldNotBeCreated);
            }
        }
        else
        {
            return Result.Failure<Guid>(result.Error);
        }
    }
}
