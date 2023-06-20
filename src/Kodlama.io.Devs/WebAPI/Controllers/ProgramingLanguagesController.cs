using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateProgramingLanguageCommand command)
        {
            CreateProgramingLanguageDto result= await Mediator.Send(command);
            return Created("", result);
        }
    }
}
