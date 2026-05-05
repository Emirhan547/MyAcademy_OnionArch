using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.SocialMediaDtos;

namespace OnionApp.WebUI.Services.SocialMediaServices
{
    public interface ISocialMediaService
    {
        Task<BaseResult<List<ResultSocialMediaDto>>> GetAllAsync();
        Task<BaseResult<UpdateSocialMediaDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateSocialMediaDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateSocialMediaDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
