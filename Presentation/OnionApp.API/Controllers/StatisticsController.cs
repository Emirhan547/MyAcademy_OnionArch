using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Queries.StatisticsQueries;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var result = await _mediator.Send(new GetCarCountQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result );
        }
        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var result=await _mediator.Send(new GetAuthorCountQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var result = await _mediator.Send(new GetLocationCountQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var result = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var result = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var result = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var result = await _mediator.Send(new GetBlogCountQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var result = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var result = await _mediator.Send(new GetBrandCountQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var result = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var result = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var result = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var result = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var result = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            var result = await _mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
        [HttpGet("GetCarCountByTranmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTranmissionIsAuto()
        {
            var result = await _mediator.Send(new GetCarCountByTranmissionIsAutoQuery());
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

    }
}
