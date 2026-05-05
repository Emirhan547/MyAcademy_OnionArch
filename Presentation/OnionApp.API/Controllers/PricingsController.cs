using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.PricingCommands;
using OnionApp.Application.Features.Queries.PricingQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var pricings = await _mediator.Send(new GetPricingsQuery());
            return pricings.IsSuccessful ? Ok(pricings) : BadRequest(pricings);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingCommand command)
        {
            var pricings=await _mediator.Send(command);
            return pricings.IsSuccessful ? Ok(pricings) : BadRequest(pricings);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pricing = await _mediator.Send(new RemovePricingCommand(id));
            return pricing.IsSuccessful?Ok(pricing):BadRequest(pricing);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePricingCommand command)
        {
            var pricing=await _mediator.Send(command);
            return pricing.IsSuccessful ? Ok(pricing) : BadRequest(pricing);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pricing=await _mediator.Send(new GetPricingByIdQuery(id));
            return pricing.IsSuccessful ? Ok(pricing) : BadRequest(pricing);
        }
    }
}
