using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.DTOs.Exercises;
using Application.Exercises.Commands.CreateExercise;
using Application.Exercises.Commands.UpdateExercise;
using Application.Exercises.Commands.BulkDeleteExercise;
using Application.Exercises.Queries.GetExercises;
using Application.Exercises.Queries.GetExerciseById;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExercisesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/exercises
    [HttpGet]
    public async Task<ActionResult<List<ExerciseDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetExercisesQuery());
        return Ok(result);
    }

    // GET: api/exercises/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ExerciseDto>> GetById(string id)
    {
        var result = await _mediator.Send(new GetExerciseByIdQuery(id));
        return Ok(result);
    }

    // POST: api/exercises
    [HttpPost]
    public async Task<ActionResult<ExerciseDto>> Create([FromBody] ExerciseCreateDto dto)
    {
        var result = await _mediator.Send(new CreateExerciseCommand(dto));
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    // PUT: api/exercises/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<ExerciseDto>> Update(string id, [FromBody] ExerciseUpdateDto dto)
    {
        var result = await _mediator.Send(new UpdateExerciseCommand(id, dto));
        return Ok(result);
    }

    // DELETE: api/exercises/bulk
    [HttpDelete("bulk")]
    public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteExercisesDto dto)
    {
        await _mediator.Send(new BulkDeleteExercisesCommand(dto.Ids));
        return NoContent();
    }
}