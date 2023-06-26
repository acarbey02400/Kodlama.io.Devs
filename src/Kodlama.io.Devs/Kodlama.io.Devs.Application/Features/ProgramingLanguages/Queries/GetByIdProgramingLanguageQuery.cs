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

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Queries
{
    public class GetByIdProgramingLanguageQuery:IRequest<ProgramingLanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery, ProgramingLanguageGetByIdDto>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _businessRules;
            public GetByIdProgramingLanguageQueryHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules businessRules)
            {
                _businessRules = businessRules;
                _mapper = mapper;
                _programingLanguageRepository = programingLanguageRepository;
            }
            public async Task<ProgramingLanguageGetByIdDto> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(p=>p.Id==request.Id); 
                _businessRules.ProgramingLanguageShouldExistWhenRequest(programingLanguage);
                ProgramingLanguageGetByIdDto mappedDto = _mapper.Map<ProgramingLanguageGetByIdDto>(programingLanguage);
                return mappedDto;
            }
        }
    }
}
