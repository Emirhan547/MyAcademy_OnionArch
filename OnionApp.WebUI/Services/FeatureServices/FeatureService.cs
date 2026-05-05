using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.FeatureDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _client;

        public FeatureService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultFeatureDto>>>("features");
        }

        public async Task<BaseResult<UpdateFeatureDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateFeatureDto>>($"features/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateFeatureDto create)
        {
            var response = await _client.PostAsJsonAsync("features", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto update)
        {
            var response = await _client.PutAsJsonAsync("features", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"features/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}