using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.LocationCommands;
using OnionApp.Application.Features.Queries.LocationQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response=await _mediator.Send(new GetLocationsQuery());
            return response.IsSuccessful?Ok(response): BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var locations=await _mediator.Send(new RemoveLocationCommand(id));
            return locations.IsSuccessful?Ok(locations): BadRequest(locations);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateLocationCommand command)
        {
            var locations = await _mediator.Send(command);
            return locations.IsSuccessful ? Ok(locations) : BadRequest(locations);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationCommand command)
        {
            var locations=await _mediator.Send(command);
            return locations.IsSuccessful ? Ok(locations) : BadRequest(locations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var locations=await _mediator.Send(new GetLocationByIdQuery(id));
            return locations.IsSuccessful ? Ok(locations) : BadRequest(locations);
        }
    }
}
