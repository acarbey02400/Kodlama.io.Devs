using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commads.CreateGitbubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubProfile, CreateGithubProfileDto>().ReverseMap();
            CreateMap<GithubProfile, CreateGithubProfileCommand>().ReverseMap();
        }
    }
}
