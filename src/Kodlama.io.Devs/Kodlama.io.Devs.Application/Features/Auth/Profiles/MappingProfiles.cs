using AutoMapper;
using Kodlama.io.Devs.Application.Features.Auth.Commands.Login;
using Kodlama.io.Devs.Application.Features.Auth.Commands.Register;
using Kodlama.io.Devs.Application.Features.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Auth.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterCommand,RegisteredDto>().ReverseMap();
            CreateMap<LoginCommand, LoginedDto>().ReverseMap();
        }
    }
}
