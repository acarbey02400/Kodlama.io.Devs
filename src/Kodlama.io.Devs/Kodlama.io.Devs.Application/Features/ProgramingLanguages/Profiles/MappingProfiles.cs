using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgramingLanguage, CreateProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, CreateProgramingLanguageCommand>().ReverseMap();
        }
    }
}
