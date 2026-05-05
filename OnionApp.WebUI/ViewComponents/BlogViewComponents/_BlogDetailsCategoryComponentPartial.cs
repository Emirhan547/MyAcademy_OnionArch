using Microsoft.AspNetCore.Mvc;
using OnionApp.WebUI.Dtos.CategoryDtos;
using OnionApp.WebUI.Services.BlogServices;
using OnionApp.WebUI.Services.CategoryServices;

namespace OnionApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentPartial(ICategoryService _categoryService, IBlogService _blogService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesResult = await _categoryService.GetAllAsync();
            var blogsResult = await _blogService.GetAllBlogsWithAuthorAsync();

            var categories = categoriesResult.Data ?? [];
            var blogCountsByCategory = (blogsResult.Data ?? [])
                .GroupBy(x => x.CategoryId)
                .ToDictionary(x => x.Key, x => x.Count());

            var model = categories.Select(category => new CategoryWithCountViewModel
            {
                Id = category.Id,
                Name = category.Name,
                BlogCount = blogCountsByCategory.GetValueOrDefault(category.Id, 0)
            }).ToList();

            return View(model);
        }
        public class CategoryWithCountViewModel : ResultCategoryDto
        {
            public int BlogCount { get; set; }
        }
    }
}
