using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class ProgramingLanguage : Entity
    {
        public ProgramingLanguage()
        {

        }
        public ProgramingLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
        public virtual ICollection<PLTechnology> PLTechnologies { get; set; }
    }
}
