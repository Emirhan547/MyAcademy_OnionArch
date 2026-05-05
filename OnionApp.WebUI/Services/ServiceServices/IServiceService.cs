using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.ServiceDtos;

namespace OnionApp.WebUI.Services.ServiceServices
{
    public interface IServiceService
    {
        Task<BaseResult<List<ResultServiceDto>>> GetAllAsync();
        Task<BaseResult<UpdateServiceDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateServiceDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateServiceDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
