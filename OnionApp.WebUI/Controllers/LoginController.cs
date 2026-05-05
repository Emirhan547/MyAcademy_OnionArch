using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnionApp.WebUI.Dtos.LoginDtos;
using OnionApp.WebUI.Dtos.RegisterDtos;
using OnionApp.WebUI.Models;
using OnionApp.WebUI.Services.AuthServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OnionApp.WebUI.Controllers
{
    public class LoginController(IAuthSessionService _authSessionService) : Controller
    {

       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto create)
        {
            var isSuccess = await _authSessionService.SignInAsync(create, HttpContext);
            if (!isSuccess)
            {
                ModelState.AddModelError(string.Empty, "Giriş başarısız.");
                return View(create);
            }

            return RedirectToAction("Index", "Statistics", new { Area = "Admin" });
        }
    }
    }
    

