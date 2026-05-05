using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.ServiceDtos;
using OnionApp.WebUI.Exceptions;
using OnionApp.WebUI.Services.ServiceServices;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.FeatureServices
{
    public class ServiceService : IServiceService
    {
        private readonly HttpClient _client;

        public ServiceService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultServiceDto>>> GetAllAsync()
        {
            return await _client
                .GetFromJsonAsync<BaseResult<List<ResultServiceDto>>>("services");
        }

        public async Task<BaseResult<UpdateServiceDto>> GetByIdAsync(int id)
        {
            return await _client
                .GetFromJsonAsync<BaseResult<UpdateServiceDto>>($"services/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateServiceDto create)
        {
            var response = await _client.PostAsJsonAsync("services", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateServiceDto update)
        {
            var response = await _client.PutAsJsonAsync("services", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

           

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"services/{id}");
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();


            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }
    }
}