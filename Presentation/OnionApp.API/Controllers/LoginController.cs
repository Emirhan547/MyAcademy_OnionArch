using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Queries.AppUserQueries;
using OnionApp.Application.Tools;

namespace OnionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController(IMediator mediator, IConfiguration configuration) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Index([FromBody] GetCheckAppUserQuery query)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            var values = await mediator.Send(query);
            if (!values.IsExist)
            {
                return Unauthorized(new ProblemDetails { Title = "Authentication failed", Detail = "Kullanıcı adı veya şifre hatalıdır" });
            }
            return Ok(JwtTokenGenerator.GenerateToken(values, configuration));
        }
    }
}
