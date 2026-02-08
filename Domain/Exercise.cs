using System;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Exercise
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public required string Title { get; set; }      //da controllare perché non legga correttamente il Required sopra di lui

    public string? Topic { get; set; }              //per ora queste 2 sono nullable perchè alcuni esercizi potrebbero non avere l'uno o l'altro

    public string? Typology { get; set; } 

    [Required]
    public ExerciseType Type { get; set; }  // Quiz / Learning

    public string? TextContent { get; set; } // spiegazione / latex
    public string? ImageUrl { get; set; }    // figura  

    [Range(0, 1000)]
    public int Difficulty { get; set; }

    public int PointsCorrect { get; set; } 
    public int PointsWrong { get; set; } 

    [Required] public string Answer1 { get; set; } = string.Empty;
    [Required] public string Answer2 { get; set; } = string.Empty;
    [Required] public string Answer3 { get; set; } = string.Empty;
    [Required] public string Answer4 { get; set; } = string.Empty;

    [Range(0,3)]
    public int CorrectAnswerIndex { get; set; }


    [Required]
    public DateTime LastUpdate { get; set; }       //per poter filtrare/eliminare/controllare solo gli esercizi inseriti/mofificati in un certo giorno

}
