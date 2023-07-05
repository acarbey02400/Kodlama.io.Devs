using AutoMapper;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Command.CreatePLTechnology
{
    public class CreatePLTechnologyCommand : IRequest<CreatePLTechnologyDto>
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public int ProgramingLanguageId { get; set; }

        public class CreatePLTechnologyHandler : IRequestHandler<CreatePLTechnologyCommand, CreatePLTechnologyDto>
        {
            private readonly IPLTechnologyRepository _pLTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly PLTechnologiesBusinessRules _businessRules;

            public CreatePLTechnologyHandler(IPLTechnologyRepository pLTechnologyRepository, IMapper mapper, PLTechnologiesBusinessRules businessRules)
            {
                _pLTechnologyRepository = pLTechnologyRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatePLTechnologyDto> Handle(CreatePLTechnologyCommand request, CancellationToken cancellationToken)
            {
               await _businessRules.SomePLTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
                PLTechnology pLTechnology = _mapper.Map<PLTechnology>(request);
                _businessRules.PLTechnologyShouldExistWhenRequest(pLTechnology);
                PLTechnology createdPLTechnology = await _pLTechnologyRepository.AddAsync(pLTechnology);
                CreatePLTechnologyDto mappedCreatePLTechnologyDto = _mapper.Map<CreatePLTechnologyDto>(createdPLTechnology);
                return mappedCreatePLTechnologyDto;
            }
        }
    }
}
