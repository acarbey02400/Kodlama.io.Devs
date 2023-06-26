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

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageCommand : IRequest<UpdateProgramingLanguageDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public class UpdateProgramingLanguageHandler : IRequestHandler<UpdateProgramingLanguageCommand, UpdateProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _rules;
            public UpdateProgramingLanguageHandler(IProgramingLanguageRepository repository, IMapper mapper, ProgramingLanguageBusinessRules rules)
            {
                _repository = repository;
                _mapper = mapper;
                _rules = rules;
            }
            public async Task<UpdateProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _rules.SomeProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);
                _rules.ProgramingLanguageShouldExistWhenRequest(mappedProgramingLanguage);
                ProgramingLanguage updatedProgramingLanguage =await _repository.UpdateAsync(mappedProgramingLanguage);
                UpdateProgramingLanguageDto updateProgramingLanguageDto =_mapper.Map<UpdateProgramingLanguageDto>(updatedProgramingLanguage);
                return updateProgramingLanguageDto;


            }
        }
    }
}
