using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Applica eventuali migration pendenti
        await context.Database.MigrateAsync();

        // Se ci sono già esercizi, NON fare nulla
        if (await context.Exercises.AnyAsync())
            return;

        var exercises = new List<Exercise>
        {
            new() {
                Id = Guid.NewGuid().ToString(),
                Title = "Equazioni di primo grado",
                Topic = "Algebra",
                Typology = "equation",
                Type = ExerciseType.Learning,
                Difficulty = 300,
                PointsCorrect = 10,
                PointsWrong = -2,
                Answer1 = "x = 2",
                Answer2 = "x = 3",
                Answer3 = "x = 4",
                Answer4 = "x = 5",
                CorrectAnswerIndex = 1,
                LastUpdate = DateTime.UtcNow
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Title = "Sistemi lineari",
                Topic = "Algebra",
                Typology = "system",
                Type = ExerciseType.Quiz,
                Difficulty = 500,
                PointsCorrect = 15,
                PointsWrong = -5,
                Answer1 = "x=1, y=2",
                Answer2 = "x=2, y=1",
                Answer3 = "x=0, y=0",
                Answer4 = "x=3, y=1",
                CorrectAnswerIndex = 0,
                LastUpdate = DateTime.UtcNow
            }
        };

        await context.Exercises.AddRangeAsync(exercises);
        await context.SaveChangesAsync();
    }
}
