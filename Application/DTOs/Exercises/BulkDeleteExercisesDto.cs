using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Exercises
{
    public class BulkDeleteExercisesDto
    {
        public List<string> Ids { get; set; } = new();
    }
}