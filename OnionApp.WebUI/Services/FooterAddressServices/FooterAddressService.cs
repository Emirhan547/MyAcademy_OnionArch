using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.FooterAddressDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.FooterAddressServices
{
    public class FooterAddressService : IFooterAddressService
    {
        private readonly HttpClient _client;

        public FooterAddressService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultFooterAddressDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultFooterAddressDto>>>("footeraddress");
        }

        public async Task<BaseResult<UpdateFooterAddressDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateFooterAddressDto>>($"footeraddress/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateFooterAddressDto create)
        {
            var response = await _client.PostAsJsonAsync("footeraddress", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateFooterAddressDto update)
        {
            var response = await _client.PutAsJsonAsync("footeraddress", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"footeraddress/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}