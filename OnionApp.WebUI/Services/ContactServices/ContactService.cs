using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.ContactDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _client;

        public ContactService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultContactDto>>>("contacts");
        }

        public async Task<BaseResult<UpdateContactDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateContactDto>>($"contacts/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateContactDto create)
        {
            var response = await _client.PostAsJsonAsync("contacts", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto update)
        {
            var response = await _client.PutAsJsonAsync("contacts", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"contacts/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}