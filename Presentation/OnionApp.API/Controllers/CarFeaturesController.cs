using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Commands.CarFeatureCommands;
using OnionApp.Application.Features.Queries.CarFeatureQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("GetCarFeaturesByCarId/{id}")]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var result = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpPut("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
           await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncelleme Yapıldı");
        }

        [HttpPut("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
           await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarCommand command)
        {

            var response = await _mediator.Send(command);
            return response.IsSuccessful? Ok(response) : BadRequest(response);
        }
    }
}
