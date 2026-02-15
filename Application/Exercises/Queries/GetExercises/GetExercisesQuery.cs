using MediatR;
using Application.DTOs.Exercises;
using System.Collections.Generic;

namespace Application.Exercises.Queries.GetExercises;

public record GetExercisesQuery() : IRequest<List<ExerciseDto>>;