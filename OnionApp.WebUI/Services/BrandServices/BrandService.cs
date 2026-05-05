using Microsoft.AspNetCore.Mvc.Rendering;
using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.BrandDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _client;

        public BrandService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateBrandDto create)
        {
            var response = await _client.PostAsJsonAsync("brands", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBrandDto update)
        {
            var response = await _client.PutAsJsonAsync("brands", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"brands/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultBrandDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultBrandDto>>>("brands");
        }

        public async Task<BaseResult<UpdateBrandDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateBrandDto>>($"brands/{id}");
        }

        public async Task<BaseResult<List<SelectListItem>>> GetBrandSelectList()
        {
            var result = await _client.GetFromJsonAsync<BaseResult<List<ResultBrandDto>>>("brands");

            if (result.Data == null)
            {
                return new BaseResult<List<SelectListItem>>
                {
                    Errors = new() { new Error { ErrorMessage = "Veri bulunamadı" } }
                };
            }

            return new BaseResult<List<SelectListItem>>
            {
                Data = result.Data.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList()
            };
        }
    }
}