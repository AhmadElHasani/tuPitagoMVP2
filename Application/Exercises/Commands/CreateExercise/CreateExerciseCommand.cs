using MediatR;
using Application.DTOs.Exercises;

namespace Application.Exercises.Commands.CreateExercise;

public record CreateExerciseCommand(ExerciseCreateDto Dto) : IRequest<ExerciseDto>;
