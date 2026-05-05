using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Commands.AuthorCommands;
using OnionApp.Application.Features.Queries.AuthorQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await _mediator.Send(new GetAuthorsQuery());
            return authors.IsSuccessful ? Ok(authors) : BadRequest(authors);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorCommand command)
        {
            var authors = await _mediator.Send(command);
            return authors.IsSuccessful ? Ok(authors) : BadRequest(authors);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAuthorCommand command)
        {
            var authors = await _mediator.Send(command);
            return authors.IsSuccessful ? Ok(authors) : BadRequest(authors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var authors = await _mediator.Send(new GetAuthorByIdQuery(id));
            return authors.IsSuccessful ? Ok(authors) : BadRequest(authors);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var authors = await _mediator.Send(new RemoveAuthorCommand(id));
            return authors.IsSuccessful?Ok(authors) : BadRequest(authors);
        }
    }
}
