using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage
{
    public class DeleteProgramingLanguageValidator:AbstractValidator<DeleteProgramingLanguageCommand>
    {
        public DeleteProgramingLanguageValidator()
        {
            RuleFor(p => p.Id).NotEmpty();   
        }
    }
}
