using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Models;
using Kodlama.io.Devs.Application.Features.ProgramingLanguages.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguagesController : BaseController
    {
        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] CreateProgramingLanguageCommand command)
        {
            CreateProgramingLanguageDto result= await Mediator.Send(command);
            return Created("", result);
        }
        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] UpdateProgramingLanguageCommand command)
        {
            UpdateProgramingLanguageDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] DeleteProgramingLanguageCommand command)
        {
            DeleteProgramingLanguageDto result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById([FromQuery] GetByIdProgramingLanguageQuery command)
        {
            ProgramingLanguageGetByIdDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpGet("getlist")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageQuery query = new() { PageRequest = pageRequest };
            ProgramingLanguageListModel result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
