using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.SocialMediaDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.SocialMediaServices
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly HttpClient _client;

        public SocialMediaService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultSocialMediaDto>>> GetAllAsync()
        {
            return await _client
                .GetFromJsonAsync<BaseResult<List<ResultSocialMediaDto>>>("socialmedias");
        }

        public async Task<BaseResult<UpdateSocialMediaDto>> GetByIdAsync(int id)
        {
            return await _client
                .GetFromJsonAsync<BaseResult<UpdateSocialMediaDto>>($"socialmedias/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateSocialMediaDto create)
        {
            var response = await _client.PostAsJsonAsync("socialmedias", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();


            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateSocialMediaDto update)
        {
            var response = await _client.PutAsJsonAsync("socialmedias", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();


            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"socialmedias/{id}");
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }
    }
}