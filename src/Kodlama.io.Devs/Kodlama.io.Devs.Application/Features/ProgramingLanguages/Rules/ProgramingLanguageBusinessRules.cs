using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Rules
{
    public class ProgramingLanguageBusinessRules
    {
        IProgramingLanguageRepository _programingLanguageRepository;
        public ProgramingLanguageBusinessRules(IProgramingLanguageRepository programingLanguageRepository)
        {
            _programingLanguageRepository = programingLanguageRepository;
        }

        public async Task SomeProgramingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLanguage> result= await _programingLanguageRepository.GetListAsync(p=>p.Name==name);
            if (result.Items.Any()) throw new BusinessException("Programing language name is exists.");
        }
        public void ProgramingLanguageShouldExistWhenRequest(ProgramingLanguage programingLanguage)
        {
            if (programingLanguage == null) throw new BusinessException("Requested programing language does not exist.");
        }
    }
}
