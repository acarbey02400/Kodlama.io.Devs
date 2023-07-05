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

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Command.DeletePLTechnology
{
    public class DeletePLTechnologyCommand : IRequest<DeletePLTechnologyDto>
    {
        public int Id { get; set; }

        public class DeletePLTechnologyHandler : IRequestHandler<DeletePLTechnologyCommand, DeletePLTechnologyDto>
        {
            private readonly IPLTechnologyRepository _pLTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly PLTechnologiesBusinessRules _businessRules;

            public DeletePLTechnologyHandler(IPLTechnologyRepository pLTechnologyRepository, IMapper mapper, PLTechnologiesBusinessRules businessRules)
            {
                _pLTechnologyRepository = pLTechnologyRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeletePLTechnologyDto> Handle(DeletePLTechnologyCommand request, CancellationToken cancellationToken)
            {
               PLTechnology pLTechnology = await _pLTechnologyRepository.GetAsync(p => p.Id == request.Id);
                pLTechnology.isDeleted = false;
                //PLTechnology pLTechnology = _mapper.Map<PLTechnology>(request);
                _businessRules.PLTechnologyShouldExistWhenRequest(pLTechnology);
                PLTechnology deletedPLTechnology = await _pLTechnologyRepository.UpdateAsync(pLTechnology);
                DeletePLTechnologyDto mappedDeletePLTechnologyDto = _mapper.Map<DeletePLTechnologyDto>(deletedPLTechnology);
                return mappedDeletePLTechnologyDto;
            }
        }
    }
}
