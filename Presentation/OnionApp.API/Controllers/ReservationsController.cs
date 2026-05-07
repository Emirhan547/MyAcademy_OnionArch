using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.API.Security;
using OnionApp.API.Services;
using OnionApp.Application.Features.Commands.ReservationCommands;
using OnionApp.Application.Features.Queries.ReservationQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController(IMediator mediator, IReservationNotifier notifier) : ControllerBase
    {
        [HttpGet("notifications/unread-count")]
        [Authorize(Policy = PolicyNames.EmployeeOnly)]
        public async Task<IActionResult> GetUnreadCount()
        {
            var count = await notifier.GetUnreadCountAsync();
            return Ok(new { Count = count });
        }

        [HttpGet("notifications/recent")]
        [Authorize(Policy = PolicyNames.EmployeeOnly)]
        public async Task<IActionResult> GetRecentNotifications()
        {
            var items = await notifier.GetRecentNotificationsAsync();
            return Ok(items);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await mediator.Send(new GetReservationQuery());
            return values.IsSuccessful ? Ok(values) : BadRequest(values);
        }
        [HttpPost]
        [Authorize(Policy = PolicyNames.MemberOrAdmin)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            await mediator.Send(command);
            return Accepted();
        }
        [HttpGet("active-rentals")]
        public async Task<IActionResult> GetActiveRentals()
        {
            var values = await mediator.Send(new GetReservationQuery());
            if (!values.IsSuccessful || values.Data == null) return BadRequest(values);
            return Ok(values.Data.Where(x => x.Status == "Rented" || x.Status == "Pending"));
        }

        [HttpGet("today-returns")]
        public async Task<IActionResult> GetTodayReturns()
        {
            var values = await mediator.Send(new GetReservationQuery());
            if (!values.IsSuccessful || values.Data == null) return BadRequest(values);

            var today = DateTime.UtcNow.Date;
            return Ok(values.Data.Where(x => x.ReturnDate.HasValue && x.ReturnDate.Value.Date == today && x.Status != "Completed"));
        }
        [HttpPost("check-out")]
        [Authorize(Policy = PolicyNames.EmployeeOnly)]
        public async Task<IActionResult> CheckOut([FromBody] UpdateReservationCheckOutCommand command)
        {
            await mediator.Send(command);
            return Accepted();
        }

        [HttpPost("check-in")]
        [Authorize(Policy = PolicyNames.EmployeeOnly)]
        public async Task<IActionResult> CheckIn([FromBody] UpdateReservationCheckInCommand command)
        {
            await mediator.Send(command);
            return Accepted();
        }
    }
}
