using Microsoft.AspNetCore.Mvc;

namespace OnionApp.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
