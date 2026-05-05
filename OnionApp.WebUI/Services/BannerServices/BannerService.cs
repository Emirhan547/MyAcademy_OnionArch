using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.BannerDtos;
using OnionApp.WebUI.Exceptions;

namespace OnionApp.WebUI.Services.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient _client;

        public BannerService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto create)
        {
            var response = await _client.PostAsJsonAsync("banners", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }
        

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"banners" + id);
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
           
        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultBannerDto>>>("banners");

        }

        public async Task<BaseResult<UpdateBannerDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateBannerDto>>("banners/" + id);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto update)
        {
            var response = await _client.PutAsJsonAsync("banners", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
            return result.IsFailure ? throw new ApiValidationException(result.Errors) : result;
        }
    }
}
