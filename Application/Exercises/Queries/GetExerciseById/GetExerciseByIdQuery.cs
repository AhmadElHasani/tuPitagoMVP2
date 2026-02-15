using MediatR;
using Application.DTOs.Exercises;

namespace Application.Exercises.Queries.GetExerciseById;

public record GetExerciseByIdQuery(string Id) : IRequest<ExerciseDto>;