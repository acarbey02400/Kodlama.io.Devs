using Kodlama.io.Devs.Application.Features.Users.Command;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateUserCommand command)
        {
            CreateUserDto createUserDto = await Mediator.Send(command);
            return Created("", createUserDto);
        }
    }
}
