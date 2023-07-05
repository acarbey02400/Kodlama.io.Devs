using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperation;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.io.Devs.Application.Features.Users.Command;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateOperationClaimCommand command)
        {
            CreateOperationClaimDto createOperationClaimDto = await Mediator.Send(command);
            return Created("", createOperationClaimDto);
        }
    }
}
