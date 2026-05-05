using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Base;
using OnionApp.Application.Features.Commands.CategoryCommands;
using OnionApp.Application.Features.Queries.CategoryQueries;
using OnionApp.Application.Features.Results.CategoryResults;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<BaseResult<List<GetCategoriesQueryResult>>>> GetAll()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResult<GetCategoryByIdQueryResult>>> GetById(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new RemoveCategoryCommand(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}