using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Command.CreatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Command.DeletePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Command.UpdatePLTechnology;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Models;
using Kodlama.io.Devs.Application.Features.PLTechnologies.Queries;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLTechnologiesController : BaseController
    {
        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] CreatePLTechnologyCommand command)
        {
            CreatePLTechnologyDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] UpdatePLTechnologyCommand command)
        {
            UpdatePLTechnologyDto result = await Mediator.Send(command);
            return Created("", result);
        }
        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] DeletePLTechnologyCommand command)
        {
            DeletePLTechnologyDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult> GetById([FromQuery]GetByIdPLTechnologyQuery query)
        {
            PLTechnologyGetByIdDto pLTechnologyGetByIdDto = await Mediator.Send(query);
            return Created("", pLTechnologyGetByIdDto);
        }
        [HttpPost("getlist")]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListPLTechnologyQuery query = new() { PageRequest = pageRequest };
            PLTechnologyListModel result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("getlist/dynamic")]
        public async Task<ActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListPLTechnologyDynamicQuery query = new GetListPLTechnologyDynamicQuery{ PageRequest=pageRequest, Dynamic= dynamic };
            PLTechnologyListModel listModel = await Mediator.Send(query);
            return Ok(listModel);
        }
    }
}
