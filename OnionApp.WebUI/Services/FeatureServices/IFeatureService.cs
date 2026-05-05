using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.FeatureDtos;

namespace OnionApp.WebUI.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync();
        Task<BaseResult<UpdateFeatureDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateFeatureDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
