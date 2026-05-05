using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.ContactDtos;
using OnionApp.WebUI.Services.ContactServices;

namespace OnionApp.WebUI.Controllers
{
    public class ContactController(IContactService _contactService) : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto create)
        {
            await _contactService.CreateAsync(create);
            return RedirectToAction("Index","Default");
        }
    }
}
