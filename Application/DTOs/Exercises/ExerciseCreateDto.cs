using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Exercises
{
    public class ExerciseCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Topic { get; set; } = string.Empty;

        [Required]
        public string Typology { get; set; } = string.Empty;

        [Required]
        [RegularExpression("quiz|learning")]
        public string Type { get; set; } = string.Empty;

        [Range(0, 1000)]
        public int Difficulty { get; set; }

        public int PointsCorrect { get; set; }
        public int PointsWrong { get; set; }

        [Required] public string Answer1 { get; set; } = string.Empty;
        [Required] public string Answer2 { get; set; } = string.Empty;
        [Required] public string Answer3 { get; set; } = string.Empty;
        [Required] public string Answer4 { get; set; } = string.Empty;

        [Range(0, 3)]
        public int CorrectAnswerIndex { get; set; }

    }
}