using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Queries.CarDescriptionQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCarDescriptionByCarId(int id)
        {
            var result = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
