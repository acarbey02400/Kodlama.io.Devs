using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos
{
    public class UpdatePLTechnologyDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? ProgramingLanguageName { get; set; }
        public int PrgramingLanguageId { get; set; }
    }
}
