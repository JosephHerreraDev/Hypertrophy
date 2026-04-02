using Hypertrophy.Application.Exercise.CreateExercise;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hypertrophy.Api.Controllers
{
    [ApiController]
    [Route("api/exercises")]
    // [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ISender _sender;

        public ExerciseController(ISender sender)
        {
            _sender = sender;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> CreateExercise(CreateExerciseCommand request, CancellationToken ct)
        {
            var command = new CreateExerciseCommand(request.Name, request.PrimaryMuscleGroup, request.SecondaryMuscleGroup, request.ExerciseMedia, request.Equipment);

            var result = await _sender.Send(command, ct);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Created();
        }

    }
}
