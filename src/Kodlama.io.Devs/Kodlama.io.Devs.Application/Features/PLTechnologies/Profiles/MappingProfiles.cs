using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Command.CreatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Command.DeletePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Command.UpdatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Models;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Queries;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<PLTechnology,CreatePLTechnologyDto>().ForMember(p => p.ProgramingLanguageName, x => x.MapFrom(c => c.ProgramingLanguage.Name)).ReverseMap();
            CreateMap<PLTechnology, CreatePLTechnologyCommand>().ReverseMap();

            CreateMap<PLTechnology, UpdatePLTechnologyDto>().ForMember(p => p.ProgramingLanguageName, x => x.MapFrom(c => c.ProgramingLanguage.Name)).ReverseMap();
            CreateMap<PLTechnology, UpdatePLTechnologyCommand>().ReverseMap();

            CreateMap<PLTechnology, DeletePLTechnologyDto>().ForMember(p => p.ProgramingLanguageName, x => x.MapFrom(c => c.ProgramingLanguage.Name)).ReverseMap();
            CreateMap<PLTechnology, DeletePLTechnologyCommand>().ReverseMap();

            CreateMap<PLTechnology, PLTechnologyListDto>().ForMember(p => p.ProgramingLanguageName, x => x.MapFrom(c => c.ProgramingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<PLTechnology>, PLTechnologyListModel>().ReverseMap();
            
            CreateMap<PLTechnology, PLTechnologyGetByIdDto>().ForMember(p => p.ProgramingLanguageName, x => x.MapFrom(c => c.ProgramingLanguage.Name)).ReverseMap();
            
        }
    }
}
