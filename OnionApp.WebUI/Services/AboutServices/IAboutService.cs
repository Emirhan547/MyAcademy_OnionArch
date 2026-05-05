using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;

namespace OnionApp.WebUI.Services.AboutServices
{
    public interface IAboutService
    {
        Task<BaseResult<List<ResultAboutDto>>> GetAllAsync();
        Task<BaseResult<UpdateAboutDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAboutDto create);
        Task<BaseResult<object>>UpdateAsync(UpdateAboutDto update);
        Task <BaseResult<object>>DeleteAsync(int id);
    }
}
