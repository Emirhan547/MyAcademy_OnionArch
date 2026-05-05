using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.CarDtos;
using System.Runtime.ConstrainedExecution;

namespace OnionApp.WebUI.Services.CarServices
{
    public interface ICarService
    {
        Task<BaseResult<List<ResultCarWithBrandsDto>>> GetCarWithBrands();
        Task<BaseResult<List<ResultLast5CarsWithBrandsDto>>> GetLast5CarWithBrands();
        Task<BaseResult<ResultCarWithBrandsDto>> GetCarWithBrandByIdAsync(int id);
        Task<BaseResult<List<ResultCarDto>>> GetAllAsync();
        Task<BaseResult<UpdateCarDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateCarDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateCarDto update);
        Task<BaseResult<object>> DeleteAsync(int id);

    }
}
