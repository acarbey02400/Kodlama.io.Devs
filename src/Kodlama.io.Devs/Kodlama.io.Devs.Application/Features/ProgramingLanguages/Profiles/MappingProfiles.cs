using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Queries;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Models;

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgramingLanguage, CreateProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, CreateProgramingLanguageCommand>().ReverseMap();
            CreateMap<ProgramingLanguage, UpdateProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, UpdateProgramingLanguageCommand>().ReverseMap();
            CreateMap<ProgramingLanguage, DeleteProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, DeleteProgramingLanguageCommand>().ReverseMap();
            CreateMap<ProgramingLanguage,GetByIdProgramingLanguageQuery >().ReverseMap();
            CreateMap<ProgramingLanguage, ProgramingLanguageGetByIdDto>().ReverseMap();
            CreateMap<IPaginate<ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
            CreateMap<ProgramingLanguage, ProgramingLanguageListDto>().ReverseMap();
        }
    }
}
