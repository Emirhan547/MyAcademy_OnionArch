using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.ReservationDtos;

namespace OnionApp.WebUI.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<bool> CreateAsync(CreateReservationDto dto);
        Task<BaseResult<List<ResultReservationDto>>> GetAllAsync();
        Task<bool> CheckOutAsync(UpdateReservationCheckOutDto dto);
        Task<bool> CheckInAsync(UpdateReservationCheckInDto dto);
    }
}
