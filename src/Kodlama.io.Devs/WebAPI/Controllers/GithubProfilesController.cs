using Kodlama.io.Devs.Application.Features.GithubProfiles.Commads.CreateGitbubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubProfilesController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Add(CreateGithubProfileCommand command)
        {
            CreateGithubProfileDto createGithubProfileDto = await Mediator.Send(command);
            return Created("", createGithubProfileDto);
        }
    }
}
