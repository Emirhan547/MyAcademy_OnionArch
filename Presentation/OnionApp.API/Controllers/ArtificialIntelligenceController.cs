using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Queries.AiQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtificialIntelligenceController(IMediator mediator) : ControllerBase
    {
        [HttpPost("car-advisor")]
        public async Task<IActionResult> GetCarAdvisor(GetCarAdvisorAiQuery query)
        {
            var result = await mediator.Send(query);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost("reservation-assistant")]
        public async Task<IActionResult> GetReservationAssistant(GetReservationAssistantAiQuery query)
        {
            var result = await mediator.Send(query);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpPost("admin-content")]
        public async Task<IActionResult> GetAdminContent(GetAdminContentAiQuery query)
        {
            var result = await mediator.Send(query);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}