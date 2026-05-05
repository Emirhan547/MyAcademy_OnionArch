using Microsoft.AspNetCore.Mvc;

namespace OnionApp.WebUI.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
