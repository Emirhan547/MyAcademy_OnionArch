using OnionApp.WebUI.Dtos.LoginDtos;

namespace OnionApp.WebUI.Services.AuthServices
{
    public interface IAuthSessionService
    {
        Task<bool> SignInAsync(CreateLoginDto loginDto, HttpContext httpContext);
    }
}
