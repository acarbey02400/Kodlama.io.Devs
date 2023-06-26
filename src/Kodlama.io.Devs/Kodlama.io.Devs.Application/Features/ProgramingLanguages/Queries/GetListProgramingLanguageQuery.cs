using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Models;
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
    public class GetListProgramingLanguageQuery:IRequest<ProgramingLanguageListModel>
    {
        public PageRequest? PageRequest { get; set; }

        public class GetListProgramingLanguageHandler : IRequestHandler<GetListProgramingLanguageQuery, ProgramingLanguageListModel>
        {
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgramingLanguageBusinessRules _businessRules;
            public GetListProgramingLanguageHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules businessRules)
            {
                _businessRules = businessRules;
                _mapper = mapper;
                _programingLanguageRepository = programingLanguageRepository;
            }
            public async Task<ProgramingLanguageListModel> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgramingLanguage> pg = await _programingLanguageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                ProgramingLanguageListModel mappedListModel = _mapper.Map<ProgramingLanguageListModel>(pg);
                return mappedListModel;
            }
        }
    }
}
