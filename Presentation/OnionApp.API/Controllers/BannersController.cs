using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Application.Features.Queries.BannerQueries;
using OnionApp.Application.Features.Results.BannerResults;


namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetBannersQueryResult>>> GetAll()
        {
            var result = await _mediator.Send(new GetBannersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBannerByIdQueryResult>> GetById(int id)
        {
            var result = await _mediator.Send(new GetBannerByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveBannerCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}

