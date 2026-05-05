using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.CommentCommands;
using OnionApp.Application.Features.Queries.CommentQueries;
using OnionApp.Domain.Entities;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            var comments = await _mediator.Send(new GetCommentsQuery());
            return comments.IsSuccessful ? Ok(comments) : BadRequest(comments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _mediator.Send(new GetCommentByIdQuery(id));
            return comment.IsSuccessful? Ok(comment) : BadRequest(comment);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentCommand create)
        {
            var comment=await _mediator.Send(create);
            return comment.IsSuccessful ? Ok(comment) : BadRequest(comment);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCommentCommand update)
        {
            var comment=await _mediator.Send(update);
            return comment.IsSuccessful ? Ok(comment) : BadRequest(comment);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _mediator.Send(new RemoveCommentCommand(id));
            return comment.IsSuccessful ? Ok(comment) : BadRequest(comment);

        }
        [HttpGet("GetCommentWithBlog/{id}")]
        public async Task<IActionResult> GetCommentWithBlog(int id)
        {
            var comment=await _mediator.Send(new GetCommentWithBlogQuery(id));
            return comment.IsSuccessful ? Ok(comment) : BadRequest(comment);
        }
        [HttpGet("GetCommentCount/{id}")]
        
        public async Task<IActionResult> GetCommentCount(int id)
        {
            var comments = await _mediator.Send(new GetCommentCountQuery(id));
            return comments.IsSuccessful ? Ok(comments) : BadRequest(comments);
        }
    }
}
