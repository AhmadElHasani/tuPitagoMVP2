using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Exercises.Commands.BulkDeleteExercise;

public class BulkDeleteExercisesHandler : IRequestHandler<BulkDeleteExercisesCommand>
{
    private readonly AppDbContext _context;

    public BulkDeleteExercisesHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(BulkDeleteExercisesCommand request, CancellationToken cancellationToken)
    {
        var exercises = await _context.Exercises
            .Where(e => request.Ids.Contains(e.Id))
            .ToListAsync(cancellationToken);

        _context.Exercises.RemoveRange(exercises);
        await _context.SaveChangesAsync(cancellationToken);
    }
}