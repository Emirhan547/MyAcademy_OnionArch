using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CarFeatureDtos;
using OnionApp.WebUI.Dtos.FeatureDtos;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.CarFeatureServices
{
    public class CarFeatureService : ICarFeatureService
    {
        private readonly HttpClient _client;

        public CarFeatureService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task ChangeCarFeatureAvailableToFalse(int id)
        {
            await _client.PutAsync($"CarFeatureChangeAvailableToFalse/{id}", null);
        }

        public async Task ChangeCarFeatureAvailableToTrue(int id)
        {
            await _client.PutAsync($"CarFeatureChangeAvailableToTrue/{id}", null);
        }

        public async Task<BaseResult<List<ResultFeatureDto>>> CreateFeatureByCarId()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultFeatureDto>>>("CarPricings");
        }

        public async Task<BaseResult<List<ResultCarFeatureByCarIdDto>>> GetCarFeaturesByCarId(int carId)
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCarFeatureByCarIdDto>>>(
                $"CarFeatures/GetCarFeaturesByCarId/{carId}");
        }
    }
}