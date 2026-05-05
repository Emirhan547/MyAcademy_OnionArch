using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.FooterAddressDtos;
using OnionApp.WebUI.Dtos.TestimonialDtos;

namespace OnionApp.WebUI.Services.FooterAddressServices
{
    public interface IFooterAddressService
    {
        Task<BaseResult<List<ResultFooterAddressDto>>> GetAllAsync();
        Task<BaseResult<UpdateFooterAddressDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateFooterAddressDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateFooterAddressDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
