using FluentValidation;

namespace Hypertrophy.Application.Exercise.CreateExercise;

public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
{
    public CreateExerciseCommandValidator()
    {
        RuleFor(e => e.Name).NotEmpty();
        RuleFor(e => e.PrimaryMuscleGroup).NotEmpty();
        RuleFor(e => e.Equipment).NotEmpty();
    }
}
