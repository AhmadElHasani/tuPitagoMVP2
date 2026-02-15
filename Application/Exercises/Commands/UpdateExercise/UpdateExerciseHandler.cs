using AutoMapper;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Exercises;

namespace Application.Exercises.Commands.UpdateExercise;

public class UpdateExerciseHandler : IRequestHandler<UpdateExerciseCommand, ExerciseDto>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateExerciseHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ExerciseDto> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        if (exercise == null)
            throw new KeyNotFoundException($"Exercise {request.Id} not found");

        _mapper.Map(request.Dto, exercise);
        exercise.LastUpdate = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ExerciseDto>(exercise);
    }
}