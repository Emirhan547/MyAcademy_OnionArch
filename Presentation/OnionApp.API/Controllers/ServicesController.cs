using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.ServiceCommands;
using OnionApp.Application.Features.Queries.ServiceQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController (IMediator _mediator): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _mediator.Send(new GetServicesQuery());
            return services.IsSuccessful?Ok(services):BadRequest(services);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var services = await _mediator.Send(new GetServiceByIdQuery(id));
            return services.IsSuccessful ? Ok(services) : BadRequest(services);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceCommand create)
        {
            var services = await _mediator.Send(create);
            return services.IsSuccessful ? Ok(services) : BadRequest(services);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceCommand update)
        {
            var services=await _mediator.Send(update);
            return services.IsSuccessful?Ok(services) : BadRequest(services);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var services=await _mediator.Send(new RemoveServiceCommand(id));
            return services.IsSuccessful ? Ok(services) : BadRequest(services);
        }
    }
}
