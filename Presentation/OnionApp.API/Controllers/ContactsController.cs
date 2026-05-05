using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.AboutCommands;
using OnionApp.Application.Features.Commands.ContactCommands;
using OnionApp.Application.Features.Queries.AboutQueries;
using OnionApp.Application.Features.Queries.ContactQueries;
using OnionApp.Application.Features.Results.AboutResults;
using OnionApp.Application.Features.Results.ContactResults;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetContactQueryResults>>> GetAll()
        {
            var result = await _mediator.Send(new GetContactQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetContactByIdQueryResult>> GetById(int id)
        {
            var result = await _mediator.Send(new GetContactByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveContactCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
