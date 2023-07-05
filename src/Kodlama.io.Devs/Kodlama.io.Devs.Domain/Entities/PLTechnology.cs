using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class PLTechnology:Entity
    {
        public PLTechnology()
        {
                
        }

        public PLTechnology(int id,string? name, string? version, int programingLanguageId):this()
        {
            Id = id;
            Name = name;
            Version = version;
            ProgramingLanguageId = programingLanguageId;
        }

        public string? Name { get; set; }
        public string? Version { get; set; }
        public int ProgramingLanguageId { get; set; }
        public virtual ProgramingLanguage? ProgramingLanguage { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
