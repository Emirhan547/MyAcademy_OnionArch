using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.ReviewCommands;
using OnionApp.Application.Features.Queries.ReviewQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController (IMediator _mediator): ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> ReviewListByCarId(int id)
        {
            var result = await _mediator.Send(new GetReviewByCarIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful?Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateReviewCommand command)
        {
            var result=await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveReviewCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
