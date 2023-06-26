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

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage
{
    public class DeleteProgramingLanguageCommand:IRequest<DeleteProgramingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgramingLanguageHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeleteProgramingLanguageDto>
        {
            private readonly IProgramingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _businessRules;
            public DeleteProgramingLanguageHandler(IProgramingLanguageRepository repository, IMapper mapper, ProgramingLanguageBusinessRules businessRules)
            {
                _businessRules = businessRules;
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<DeleteProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);
                _businessRules.ProgramingLanguageShouldExistWhenRequest(mappedProgramingLanguage);
                ProgramingLanguage deletedProgramingLanguage=await _repository.DeleteAsync(mappedProgramingLanguage);
                DeleteProgramingLanguageDto deleteProgramingLanguageDto=_mapper.Map<DeleteProgramingLanguageDto>(deletedProgramingLanguage);
                return deleteProgramingLanguageDto;
            }
        }
    }
}
