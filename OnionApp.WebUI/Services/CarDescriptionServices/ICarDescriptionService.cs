using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CarDescriptionDtos;

namespace OnionApp.WebUI.Services.CarDescriptionServices
{
    public interface ICarDescriptionService
    {
       Task <BaseResult<ResultCarDescriptionByCarIdDto>> GetCarDescription(int carId);

    }
}
