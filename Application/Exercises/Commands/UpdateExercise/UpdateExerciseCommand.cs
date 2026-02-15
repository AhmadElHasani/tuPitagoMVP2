using MediatR;
using Application.DTOs.Exercises;

namespace Application.Exercises.Commands.UpdateExercise;

public record UpdateExerciseCommand(string Id, ExerciseUpdateDto Dto) : IRequest<ExerciseDto>;