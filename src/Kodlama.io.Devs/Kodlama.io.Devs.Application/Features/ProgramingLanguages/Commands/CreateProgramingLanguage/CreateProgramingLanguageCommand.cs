using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage
{
    public class CreateProgramingLanguageCommand : IRequest<CreateProgramingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgramingLanguageHandler : IRequestHandler<CreateProgramingLanguageCommand, CreateProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _businessRules;
            public CreateProgramingLanguageHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules businessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.SomeProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);

                _businessRules.ProgramingLanguageShouldExistWhenRequest(mappedProgramingLanguage);

                ProgramingLanguage createdProgramingLanguage = await _programingLanguageRepository
                    .AddAsync(mappedProgramingLanguage);

                CreateProgramingLanguageDto createdProgramingLanguageDto = _mapper
                    .Map<CreateProgramingLanguageDto>(createdProgramingLanguage);

                return createdProgramingLanguageDto;
            }
        }
    }
}
