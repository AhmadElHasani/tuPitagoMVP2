using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Application.DTOs.Exercises;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Exercise, ExerciseDto>();
            CreateMap<ExerciseCreateDto, Exercise>();
        }
    }
}