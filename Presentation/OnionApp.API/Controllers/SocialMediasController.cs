using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.SocialMediaCommands;
using OnionApp.Application.Features.Queries.SocialMediaQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetSocialMediasQuery());
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand create)
        {
            var response = await _mediator.Send(create);
            return response.IsSuccessful ? Ok(response): BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand update)
        {
            var response=await _mediator.Send(update);
            return response.IsSuccessful ? Ok(response) :BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response=await _mediator.Send(new RemoveSocialMediaCommand(id));
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
