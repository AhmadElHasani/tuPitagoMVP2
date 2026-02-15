using MediatR;
using Application.DTOs.Exercises;

namespace Application.Exercises.Commands.BulkDeleteExercise;

public record BulkDeleteExercisesCommand(List<string> Ids) : IRequest;