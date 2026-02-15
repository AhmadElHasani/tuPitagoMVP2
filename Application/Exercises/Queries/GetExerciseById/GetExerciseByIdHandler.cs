using AutoMapper;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Exercises;

namespace Application.Exercises.Queries.GetExerciseById;

public class GetExerciseByIdHandler : IRequestHandler<GetExerciseByIdQuery, ExerciseDto>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetExerciseByIdHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ExerciseDto> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
    {
        var exercise = await _context.Exercises
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (exercise == null)
            throw new KeyNotFoundException($"Exercise {request.Id} not found");

        return _mapper.Map<ExerciseDto>(exercise);
    }
}