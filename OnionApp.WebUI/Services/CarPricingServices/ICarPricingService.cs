using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CarPricingDtos;

namespace OnionApp.WebUI.Services.CarPricingServices
{
    public interface ICarPricingService
    {
        Task<BaseResult<List<ResultCarPricingWithCarDto>>> GetCarPricingWithCar();

        Task<BaseResult<List<ResultCarPricingListWithModelDto>>> GetCarPricingWithTimePeriod();
    }
}
