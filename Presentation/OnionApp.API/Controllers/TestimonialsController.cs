using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.TestimonialCommands;
using OnionApp.Application.Features.Queries.TestimonialQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var testimonials = await _mediator.Send(new GetTestimonialsQuery());
            return testimonials.IsSuccessful ? Ok(testimonials) : BadRequest(testimonials);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialCommand create)
        {
            var testimonials = await _mediator.Send(create);
            return testimonials.IsSuccessful?Ok(testimonials):BadRequest(testimonials);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return response.IsSuccessful?Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialCommand update)
        {
            var response=await _mediator.Send(update);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var testimonials = await _mediator.Send(new RemoveTestimonialCommand(id));
            return testimonials.IsSuccessful?Ok(testimonials) : BadRequest(testimonials);
        }
    }
}
