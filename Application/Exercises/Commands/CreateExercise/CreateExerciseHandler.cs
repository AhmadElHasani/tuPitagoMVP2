using AutoMapper;
using MediatR;
using Persistence;
using Domain;
using Application.DTOs.Exercises;

namespace Application.Exercises.Commands.CreateExercise;

public class CreateExerciseHandler : IRequestHandler<CreateExerciseCommand, ExerciseDto>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CreateExerciseHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ExerciseDto> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = _mapper.Map<Exercise>(request.Dto);
        exercise.LastUpdate = DateTime.UtcNow;

        await _context.Exercises.AddAsync(exercise, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ExerciseDto>(exercise);
    }
}