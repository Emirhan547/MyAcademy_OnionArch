using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CarFeatureDtos;
using OnionApp.WebUI.Dtos.FeatureDtos;

namespace OnionApp.WebUI.Services.CarFeatureServices
{
    public interface ICarFeatureService
    {
        Task<BaseResult<List<ResultCarFeatureByCarIdDto>>> GetCarFeaturesByCarId(int carId);
        Task ChangeCarFeatureAvailableToFalse(int id);
        Task ChangeCarFeatureAvailableToTrue(int id);
        Task<BaseResult<List<ResultFeatureDto>>> CreateFeatureByCarId();
    }
}
