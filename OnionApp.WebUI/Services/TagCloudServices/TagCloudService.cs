using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.TagCloudDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.TagCloudServices
{
    public class TagCloudService : ITagCloudService
    {
        private readonly HttpClient _client;

        public TagCloudService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateTagCloudDto create)
        {
            var response = await _client.PostAsJsonAsync("tagclouds", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"tagclouds/{id}");
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<List<ResultTagCloudDto>>> GetAllAsync()
        {
            return await _client
                .GetFromJsonAsync<BaseResult<List<ResultTagCloudDto>>>("tagclouds");
        }

        public async Task<BaseResult<List<ResultGetByBlogIdTagCloudDto>>> GetTagCloudById(int id)
        {
            return await _client
                .GetFromJsonAsync<BaseResult<List<ResultGetByBlogIdTagCloudDto>>>($"tagclouds/GetTagCloudById?id={id}");
        }

        public async Task<BaseResult<UpdateTagCloudDto>> GetByIdAsync(int id)
        {
            return await _client
                .GetFromJsonAsync<BaseResult<UpdateTagCloudDto>>($"tagclouds/{id}");
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTagCloudDto update)
        {
            var response = await _client.PutAsJsonAsync("tagclouds", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }
    }
}