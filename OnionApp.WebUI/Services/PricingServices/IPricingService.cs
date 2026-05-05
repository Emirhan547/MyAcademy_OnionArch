using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.PricingDtos;

namespace OnionApp.WebUI.Services.PricingServices
{
    public interface IPricingService
    {
        Task<BaseResult<List<ResultPricingDto>>> GetAllAsync();
        Task<BaseResult<UpdatePricingDto>> GetByIdAsync(int id);
        Task <BaseResult<object>> CreateAsync(CreatePricingDto dto);
        Task <BaseResult<object>> UpdateAsync(UpdatePricingDto dto);
        Task <BaseResult<object>> DeleteAsync(int id);
    }
}
