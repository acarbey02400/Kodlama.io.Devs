using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageValidator:AbstractValidator<UpdateProgramingLanguageCommand>
    {
        public UpdateProgramingLanguageValidator() 
        {
            RuleFor(p=>p.Name).NotEmpty();
            RuleFor(p=>p.Id).NotEmpty();
        }
    }
}
