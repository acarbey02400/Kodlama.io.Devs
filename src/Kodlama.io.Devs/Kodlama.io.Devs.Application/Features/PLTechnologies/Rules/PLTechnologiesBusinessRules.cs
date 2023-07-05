using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Rules
{
    public class PLTechnologiesBusinessRules
    {
        IPLTechnologyRepository _pLTechnologyRepository;

        public PLTechnologiesBusinessRules(IPLTechnologyRepository pLTechnologyRepository)
        {
            _pLTechnologyRepository = pLTechnologyRepository;
        }

        public async Task SomePLTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<PLTechnology> result = await _pLTechnologyRepository.GetListAsync(p => p.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programing language name is exists.");
        }
        public void PLTechnologyShouldExistWhenRequest(PLTechnology pLTechnology)
        {
            if (pLTechnology == null) throw new BusinessException("Requested programing language does not exist.");
        }
    }
}
