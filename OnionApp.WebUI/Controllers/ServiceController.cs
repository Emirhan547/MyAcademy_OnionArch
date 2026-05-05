using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.ServiceServices;

namespace OnionApp.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
