using Hypertrophy.Application.Abstractions.Messaging;
using Hypertrophy.Domain.Shared;

namespace Hypertrophy.Application.Exercise.CreateExercise;

public record MediaCommand(
    int Kind,
    Uri Url,
    string? ThumbnailUrl = null,
    string? MimeType = null,
    int? Width = null,
    int? Height = null,
    TimeSpan? Duration = null);
public record CreateExerciseCommand(
    string Name,
    ICollection<int> PrimaryMuscleGroup,
    ICollection<int> SecondaryMuscleGroup,
    ICollection<MediaCommand> ExerciseMedia,
    eEquipment Equipment
) : ICommand<Guid>;
