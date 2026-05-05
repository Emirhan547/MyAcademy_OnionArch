using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.TagCloudCommands;
using OnionApp.Application.Features.Queries.TagCloudQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediator.Send(new GetTagCloudsQuery());
            return values.IsSuccessful?Ok(values):BadRequest(values);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTagCloudCommand command)
        {
            var values = await _mediator.Send(command);
            return values.IsSuccessful ? Ok(values) : BadRequest(values);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTagCloudCommand command)
        {
            var values=await _mediator.Send(command);
            return values.IsSuccessful?Ok(values) : BadRequest(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return values.IsSuccessful ? Ok(values) : BadRequest(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var values = await _mediator.Send(new RemoveTagCloudCommand(id));
            return values.IsSuccessful ? Ok(values) : BadRequest(values);
        }
        [HttpGet("GetTagCloudById")]
        public async Task<IActionResult> GetTagCloudById(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return values.IsSuccessful ? Ok(values) : BadRequest(values);
        }
    }
}
