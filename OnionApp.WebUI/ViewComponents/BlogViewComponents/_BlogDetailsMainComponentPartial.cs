using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.BlogDtos;
using OnionApp.WebUI.Services.BlogServices;

namespace OnionApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(ResultGetBlogByIdDto model)
        {
            if (model == null)
            {
                return Content("Blog bulunamadı");
            }

            return View(model);
        }
    }
}
