using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commads.CreateGitbubProfile
{
    public class CreateGithubProfileCommand:IRequest<CreateGithubProfileDto>
    {
        public int UserId { get; set; }
        public string? GithubUrl { get; set; }

        public class CreateGithubProfileHandler : IRequestHandler<CreateGithubProfileCommand, CreateGithubProfileDto>
        {
            private readonly IGithubProfileRepository _repository;
            private readonly IMapper _mapper;

            public CreateGithubProfileHandler(IGithubProfileRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CreateGithubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                GithubProfile githubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile createdGithubProfile = await _repository.AddAsync(githubProfile);
                CreateGithubProfileDto mappedGithubProfileDto = _mapper.Map<CreateGithubProfileDto>(createdGithubProfile);
                return mappedGithubProfileDto;
            }
        }
    }
}
