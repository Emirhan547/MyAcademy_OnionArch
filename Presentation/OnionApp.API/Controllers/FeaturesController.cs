using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Commands.FeatureCommands;
using OnionApp.Application.Features.Queries.FeatureQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var features = await _mediator.Send(new GetFeaturesQuery());
            return features.IsSuccessful ? Ok(features) : BadRequest(features);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var features = await _mediator.Send(new GetFeatureByIdQuery(id));
            return features.IsSuccessful ? Ok(features) : BadRequest(features);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureCommand create)
        {
            var features = await _mediator.Send(create);
            return features.IsSuccessful ? Ok(features) : BadRequest(features);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureCommand update)
        {
            var features = await _mediator.Send(update);
            return features.IsSuccessful ? Ok(features) : BadRequest(features);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var features = await _mediator.Send(new RemoveFeatureCommand(id));
            return features.IsSuccessful ? Ok(features) : BadRequest(features);
        }
    }
}