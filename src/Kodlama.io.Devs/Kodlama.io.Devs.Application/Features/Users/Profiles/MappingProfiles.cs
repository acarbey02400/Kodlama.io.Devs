﻿using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Users.Command;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
