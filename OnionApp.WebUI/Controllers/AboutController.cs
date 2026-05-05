using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.AboutServices;

namespace OnionApp.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
