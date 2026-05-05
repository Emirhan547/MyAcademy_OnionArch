using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.AuthorDtos;
using OnionApp.WebUI.Exceptions;

namespace OnionApp.WebUI.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _client;

        public AuthorService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }
        public async Task<BaseResult<List<ResultAuthorDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultAuthorDto>>>("authors");
        }

        public async Task<BaseResult<UpdateAuthorDto>> GetByIdAsync(int id)
        {
          

            return await _client.GetFromJsonAsync<BaseResult<UpdateAuthorDto>>("authors/" + id);
        }

        public async Task<BaseResult<object>> CreateAsync(CreateAuthorDto create)
        {
            var response = await _client.PostAsJsonAsync("authors", create);

            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAuthorDto update)
        {
            var response = await _client.PutAsJsonAsync("authors", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result; ;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"authors/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}
