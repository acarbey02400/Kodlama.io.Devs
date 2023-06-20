﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage
{
    internal class CreateProgramingLanguageValidator:AbstractValidator<CreateProgramingLanguageCommand>
    {
        public CreateProgramingLanguageValidator()
        {
         RuleFor(p=>p.Name).NotEmpty();
        }
    }
}
