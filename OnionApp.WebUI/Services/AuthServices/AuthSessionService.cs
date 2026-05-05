using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnionApp.WebUI.Dtos.LoginDtos;
using OnionApp.WebUI.Extensions;
using OnionApp.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace OnionApp.WebUI.Services.AuthServices
{
    public class AuthSessionService(IHttpClientFactory factory) : IAuthSessionService
    {
        public async Task<bool> SignInAsync(CreateLoginDto loginDto, HttpContext httpContext)
        {
            var client = factory.CreateClient("ApiClient");
            var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Login", content);
            if (!response.IsSuccessStatusCode) return false;
            var jsonData = await response.Content.ReadAsStringAsync();
            var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            if (tokenModel?.Token is null) return false;
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(tokenModel.Token);
            var claims = token.Claims.ToList();
            claims.Add(new Claim("carbooktoken", tokenModel.Token));
            var claimsIdentity = new ClaimsIdentity(claims, AuthSchemes.AppCookie);
            var authProps = new AuthenticationProperties { ExpiresUtc = tokenModel.ExpireDate, IsPersistent = true };
            await httpContext.SignInAsync(AuthSchemes.AppCookie, new ClaimsPrincipal(claimsIdentity), authProps);
            return true;
        }
    }
}