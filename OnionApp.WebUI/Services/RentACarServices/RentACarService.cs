using OnionApp.WebUI.Dtos.RentACarDtos;

namespace OnionApp.WebUI.Services.RentACarServices
{
    public class RentACarService : IRentACarService
    {
        private readonly HttpClient _client;

        public RentACarService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<List<FilterRentACarDto>> GetAvailableCarsAsync(int locationId)
        {
            try
            {
                var response = await _client.GetAsync($"RentACars?locationID={locationId}&available=true");

                if (!response.IsSuccessStatusCode)
                    return new List<FilterRentACarDto>();

                var values = await response.Content.ReadFromJsonAsync<List<FilterRentACarDto>>();

                return values ?? new List<FilterRentACarDto>();
            }
            catch
            {
                return new List<FilterRentACarDto>();
            }
        }
    }
}
