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

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Command.UpdatePLTechnology
{
    public class UpdatePLTechnologyCommand : IRequest<UpdatePLTechnologyDto>
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public int ProgramingLanguageId { get; set; }

        public class UpdatePLTechnologyHandler : IRequestHandler<UpdatePLTechnologyCommand, UpdatePLTechnologyDto>
        {
            private readonly IPLTechnologyRepository _pLTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly PLTechnologiesBusinessRules _businessRules;

            public UpdatePLTechnologyHandler(IPLTechnologyRepository pLTechnologyRepository, IMapper mapper, PLTechnologiesBusinessRules businessRules)
            {
                _pLTechnologyRepository = pLTechnologyRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatePLTechnologyDto> Handle(UpdatePLTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.SomePLTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
                PLTechnology pLTechnology = _mapper.Map<PLTechnology>(request);
                _businessRules.PLTechnologyShouldExistWhenRequest(pLTechnology);
                PLTechnology updatedPLTechnology = await _pLTechnologyRepository.UpdateAsync(pLTechnology);
                UpdatePLTechnologyDto mappedUpdatePLTechnologyDto = _mapper.Map<UpdatePLTechnologyDto>(updatedPLTechnology);
                return mappedUpdatePLTechnologyDto;
            }
        }
    }
}
