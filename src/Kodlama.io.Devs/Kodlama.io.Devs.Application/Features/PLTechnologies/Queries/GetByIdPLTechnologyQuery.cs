using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Models;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Queries
{
    public class GetByIdPLTechnologyQuery : IRequest<PLTechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdPLTechnologyHandler : IRequestHandler<GetByIdPLTechnologyQuery, PLTechnologyGetByIdDto>
        {
            private readonly IPLTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly PLTechnologiesBusinessRules _businessRules;

            public GetByIdPLTechnologyHandler(IPLTechnologyRepository repository, IMapper mapper, PLTechnologiesBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<PLTechnologyGetByIdDto> Handle(GetByIdPLTechnologyQuery request, CancellationToken cancellationToken)
            {
                PLTechnology pLTechnology = await _repository.GetAsync(p => p.Id == request.Id,include:p=>p.Include(x=>x.ProgramingLanguage));
                _businessRules.PLTechnologyShouldExistWhenRequest(pLTechnology);
                PLTechnologyGetByIdDto mappedPLTechnologyGetByIdDto = _mapper.Map<PLTechnologyGetByIdDto>(pLTechnology);
                return mappedPLTechnologyGetByIdDto;
            }
        }
    }
}
