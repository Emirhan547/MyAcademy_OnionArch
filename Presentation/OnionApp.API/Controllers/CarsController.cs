using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.API.Security;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Application.Features.Queries.BrandQueries;
using OnionApp.Application.Features.Queries.CarQueries;
using OnionApp.Application.Features.Queries.StatisticsQueries;
using OnionApp.Domain.Entities;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController (IMediator _mediator): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _mediator.Send(new GetCarQuery());
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brands = await _mediator.Send(new GetCarByIdQuery(id));
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpPost]
        [Authorize(Policy = PolicyNames.EmployeeOnly)]
        public async Task<IActionResult> Create(CreateCarCommand command)
        {
            var brands = await _mediator.Send(command);
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpPut]
        [Authorize(Policy = PolicyNames.EmployeeOnly)]
        public async Task<IActionResult> Update(UpdateCarCommand command)
        {
            var brands = await _mediator.Send(command);
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var brands = await _mediator.Send(new RemoveCarCommand(id));
            return brands.IsSuccessful ? Ok(brands) : BadRequest(brands);
        }
        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult>GetCarWithBrand()
        {
            var values = await _mediator.Send(new GetCarWithBrandQuery());
            return values.IsSuccessful ? Ok(values) : BadRequest(values);
        }
        [HttpGet("GetCarWithBrandById/{id}")]
        public async Task<IActionResult> GetCarWithBrandById(int id)
        {
            var values = await _mediator.Send(new GetCarWithBrandByIdQuery(id));
            return values.IsSuccessful ? Ok(values) : BadRequest(values);
        }
        [HttpGet("GetLast5CarsWithBrand")]
        public async Task<IActionResult> GetLast5CarsWithBrand()
        {
            var values=await _mediator.Send(new GetCarWithBrandQuery());
            return values.IsSuccessful?Ok(values) : BadRequest(values);
        }
        


    }
}
