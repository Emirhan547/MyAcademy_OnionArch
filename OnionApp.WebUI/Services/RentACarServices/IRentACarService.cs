using OnionApp.WebUI.Dtos.RentACarDtos;

namespace OnionApp.WebUI.Services.RentACarServices
{
    public interface IRentACarService
    {
        Task<List<FilterRentACarDto>> GetAvailableCarsAsync(int locationId);
    }
}
