using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CarPricingDtos;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.CarPricingServices
{
    public class CarPricingService : ICarPricingService
    {
        private readonly HttpClient _client;

        public CarPricingService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultCarPricingWithCarDto>>> GetCarPricingWithCar()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCarPricingWithCarDto>>>("carpricings");
        }

        public async Task<BaseResult<List<ResultCarPricingListWithModelDto>>> GetCarPricingWithTimePeriod()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCarPricingListWithModelDto>>>(
                "carpricings/GetCarPricingWithTimePeriod");
        }

       
    }
}