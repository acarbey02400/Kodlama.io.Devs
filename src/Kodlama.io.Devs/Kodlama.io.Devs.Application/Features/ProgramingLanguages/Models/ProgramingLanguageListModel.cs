using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgramingLanguages.Models
{
    public class ProgramingLanguageListModel:BasePageableModel
    {
        public IList<ProgramingLanguageListDto>? Items { get; set; }
    }
}
