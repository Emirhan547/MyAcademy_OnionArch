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
        public async Task<int> GetTodayReservationCountAsync()
        {
            var all = await GetAllAsync();
            if (!all.IsSuccessful || all.Data == null) return 0;

            var today = DateTime.Today;
            return all.Data.Count(x => x.PickUpDate.HasValue && x.PickUpDate.Value.Date == today);
        }


        public async Task<int> GetUnreadCountAsync()
        {
            var response = await _client.GetFromJsonAsync<System.Text.Json.Nodes.JsonObject>("Reservations/notifications/unread-count");
            return response?["count"]?.GetValue<int>() ?? 0;
        }

        public async Task<List<object>> GetRecentNotificationsAsync()
        {
            var response = await _client.GetFromJsonAsync<List<object>>("Reservations/notifications/recent");
            return response ?? [];
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
