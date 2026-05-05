using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.PricingDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.PricingServices
{
    public class PricingService : IPricingService
    {
        private readonly HttpClient _client;

        public PricingService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultPricingDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultPricingDto>>>("pricings");
        }

        public async Task<BaseResult<UpdatePricingDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdatePricingDto>>($"pricings/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreatePricingDto dto)
        {
            var response = await _client.PostAsJsonAsync("pricings", dto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdatePricingDto dto)
        {
            var response = await _client.PutAsJsonAsync("pricings", dto);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"pricings/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}