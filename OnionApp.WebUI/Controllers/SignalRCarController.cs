using Microsoft.AspNetCore.Mvc;

namespace OnionApp.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
