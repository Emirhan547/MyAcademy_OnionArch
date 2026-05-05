using Microsoft.AspNetCore.Mvc.Rendering;
using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.BrandDtos;

namespace OnionApp.WebUI.Services.BrandServices
{
    public interface IBrandService
    {
        Task<BaseResult<List<SelectListItem>>> GetBrandSelectList();
        Task<BaseResult<List<ResultBrandDto>>> GetAllAsync();
        Task<BaseResult<UpdateBrandDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateBrandDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateBrandDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
