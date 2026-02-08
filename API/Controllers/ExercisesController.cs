using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace API.Controllers;

public class ExercisesController(AppDbContext context) : BaseApiController
{
    private readonly AppDbContext _context = context;

    // GET: api/exercises
    [HttpGet]
    public async Task<ActionResult<List<Exercise>>> GetExercises()
    {
        return await _context.Exercises
            .OrderBy(x => x.Topic)
            .ToListAsync();
    }

    // GET: api/exercises/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExercise(string id)
    {
        var exercise = await _context.Exercises.FindAsync(id);

        if (exercise == null)
            return NotFound();

        return exercise;
    }
}
