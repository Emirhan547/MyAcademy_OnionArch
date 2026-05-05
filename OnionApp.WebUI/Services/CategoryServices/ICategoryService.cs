using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.CategoryDtos;

namespace OnionApp.WebUI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync();
        Task<BaseResult<UpdateCategoryDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateCategoryDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
