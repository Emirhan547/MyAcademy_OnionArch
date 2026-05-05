using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.ReservationDtos;

namespace OnionApp.WebUI.Services.ReservationServices
{
    public class ReservationService:IReservationService
    {
        private readonly HttpClient _client;

        public ReservationService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<bool> CreateAsync(CreateReservationDto dto)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Reservations", dto);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> CheckOutAsync(UpdateReservationCheckOutDto dto)
        {
            var response = await _client.PostAsJsonAsync("Reservations/check-out", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CheckInAsync(UpdateReservationCheckInDto dto)
        {
            var response = await _client.PostAsJsonAsync("Reservations/check-in", dto);
            return response.IsSuccessStatusCode;
        }
        public async Task<BaseResult<List<ResultReservationDto>>> GetAllAsync()
        {
            var response = await _client.GetAsync("reservations");

            var result = await response.Content.ReadFromJsonAsync<BaseResult<List<ResultReservationDto>>>();

            return result ?? new BaseResult<List<ResultReservationDto>>
            {
                Errors = new() { new Error { ErrorMessage = "Deserialize hatası" } }
            };
        }
    }
}
