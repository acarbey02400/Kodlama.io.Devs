using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperation;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateUserOperationClaimCommand command)
        {
            CreateUserOperationClaimDto createUserOperationClaimDto = await Mediator.Send(command);
            return Created("", createUserOperationClaimDto);
        }
    }
}
