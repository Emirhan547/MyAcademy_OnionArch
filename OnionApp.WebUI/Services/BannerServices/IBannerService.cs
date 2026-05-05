using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.BannerDtos;
using OnionApp.WebUI.Dtos.ContactDtos;

namespace OnionApp.WebUI.Services.BannerServices
{
    public interface IBannerService
    {
        Task<BaseResult<List<ResultBannerDto>>> GetAllAsync();
        Task<BaseResult<UpdateBannerDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateBannerDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateBannerDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
