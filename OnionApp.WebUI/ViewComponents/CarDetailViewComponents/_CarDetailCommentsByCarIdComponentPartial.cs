using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Services.ReviewServices;

namespace OnionApp.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentsByCarIdComponentPartial(IReviewService _service):ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var result = await _service.GetReviewsByCarId(id);
            return View(result.Data);
        }
    }
}
