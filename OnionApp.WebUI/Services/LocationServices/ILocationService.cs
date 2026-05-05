using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.LocationDtos;

namespace OnionApp.WebUI.Services.LocationServices
{
    public interface ILocationService
    {
        Task<BaseResult<List<ResultLocationDto>>> GetAllAsync();
        Task<BaseResult<UpdateLocationDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateLocationDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateLocationDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
