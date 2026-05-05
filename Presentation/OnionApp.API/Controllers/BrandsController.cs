using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Application.Features.Queries.BrandQueries;
using System.Threading.Tasks;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _mediator.Send(new GetBrandsQuery());
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetBrands(int id)
        {
            var brands=await _mediator.Send(new GetBrandByIdQuery(id));
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateBrandCommand command)
        {
            var brands = await _mediator.Send(command);
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateBrandCommand command)
        {
            var brands=await _mediator.Send(command);
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            var brands=await _mediator.Send(new RemoveBrandCommand(id));
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
    }
}
