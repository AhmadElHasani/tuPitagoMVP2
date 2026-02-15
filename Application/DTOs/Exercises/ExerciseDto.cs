using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Exercises
{
    public class ExerciseDto
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string Typology { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty; // "quiz" | "learning"

        public int Difficulty { get; set; }

        public int PointsCorrect { get; set; }
        public int PointsWrong { get; set; }

        public string Answer1 { get; set; } = string.Empty;
        public string Answer2 { get; set; } = string.Empty;
        public string Answer3 { get; set; } = string.Empty;
        public string Answer4 { get; set; } = string.Empty;

        public int CorrectAnswerIndex { get; set; }

        public DateTime LastUpdate { get; set; }

    }
}