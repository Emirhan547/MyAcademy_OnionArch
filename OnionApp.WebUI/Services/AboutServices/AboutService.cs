using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;
using System.Text.Json;

namespace OnionApp.WebUI.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _client;

        public AboutService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultAboutDto>>>("abouts");
        }

        public async Task<BaseResult<UpdateAboutDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateAboutDto>> ("abouts/"+id);
        }

        public async Task<BaseResult<object>> CreateAsync(CreateAboutDto create)
        {
            var response = await _client.PostAsJsonAsync("abouts", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result; }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto update)
        {
            var response = await _client.PutAsJsonAsync("abouts", update);
            var result=await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync("abouts/" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}