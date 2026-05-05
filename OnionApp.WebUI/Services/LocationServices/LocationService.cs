using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.LocationDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _client;

        public LocationService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultLocationDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultLocationDto>>>("locations");
        }

        public async Task<BaseResult<UpdateLocationDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateLocationDto>>($"locations/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateLocationDto create)
        {
            var response = await _client.PostAsJsonAsync("locations", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateLocationDto update)
        {
            var response = await _client.PutAsJsonAsync("locations", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"locations/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}