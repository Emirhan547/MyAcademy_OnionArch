using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.BannerCommands;
using OnionApp.Application.Features.Commands.BlogCommands;
using OnionApp.Application.Features.Queries.BannerQueries;
using OnionApp.Application.Features.Queries.BlogQueries;
using OnionApp.Application.Features.Results.BannerResults;
using OnionApp.Application.Features.Results.BlogResults;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetBlogsQueryResult>>> GetAll()
        {
            var result = await _mediator.Send(new GetBlogsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBlogByIdQueryResult>> GetById(int id)
        {
            var result = await _mediator.Send(new GetBlogByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveBlogCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetLast3BlogsWithAuthors")]
        public async Task <IActionResult> GetLast3BlogsWithAuthors()
        {
            var result = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetAllBlogsWithAuthor")]
        public async Task<IActionResult> GetAllBlogsWithAuthor([FromQuery] int? categoryId = null)
        {
            var result = await _mediator.Send(new GetAllBlogsWithAuthorQuery(categoryId));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetBlogByAuthorId")]
        public async Task<IActionResult> GetBlogByAuthorId(int id)
        {
            var result=await _mediator.Send(new GetBlogByAuthorIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

    }
}
