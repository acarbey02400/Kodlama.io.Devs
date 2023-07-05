using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Dtos
{
    public class CreateOperationClaimDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
