using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CarDescriptionDtos;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.CarDescriptionServices
{
    public class CarDescriptionService : ICarDescriptionService
    {
        private readonly HttpClient _client;

        public CarDescriptionService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<ResultCarDescriptionByCarIdDto>> GetCarDescription(int carId)
        {
            return await _client.GetFromJsonAsync<BaseResult<ResultCarDescriptionByCarIdDto>>($"CarDescriptions/{carId}");
        }
    }
}