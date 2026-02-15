using AutoMapper;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Exercises;

namespace Application.Exercises.Queries.GetExercises;

public class GetExercisesHandler : IRequestHandler<GetExercisesQuery, List<ExerciseDto>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetExercisesHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ExerciseDto>> Handle(GetExercisesQuery request, CancellationToken cancellationToken)
    {
        var exercises = await _context.Exercises.ToListAsync(cancellationToken);
        return _mapper.Map<List<ExerciseDto>>(exercises);
    }
}