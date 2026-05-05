using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CategoryDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCategoryDto>>>("categories");
        }

        public async Task<BaseResult<UpdateCategoryDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateCategoryDto>>($"categories/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto create)
        {
            var response = await _client.PostAsJsonAsync("categories", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto update)
        {
            var response = await _client.PutAsJsonAsync("categories", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"categories/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}