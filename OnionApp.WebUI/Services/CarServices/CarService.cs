using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CarDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.CarServices
{
    public class CarService : ICarService
    {
        private readonly HttpClient _client;

        public CarService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultCarWithBrandsDto>>> GetCarWithBrands()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCarWithBrandsDto>>>("cars/GetCarWithBrand");
        }

        public async Task<BaseResult<List<ResultLast5CarsWithBrandsDto>>> GetLast5CarWithBrands()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultLast5CarsWithBrandsDto>>>("cars/GetLast5CarsWithBrand");
        }

        public async Task<BaseResult<List<ResultCarDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCarDto>>>("cars");
        }

        public async Task<BaseResult<UpdateCarDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateCarDto>>($"cars/{id}");
        }

        public async Task<BaseResult<ResultCarWithBrandsDto>> GetCarWithBrandByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<ResultCarWithBrandsDto>>($"cars/GetCarWithBrandById/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateCarDto create)
        {
            var response = await _client.PostAsJsonAsync("cars", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCarDto update)
        {
            var response = await _client.PutAsJsonAsync("cars", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"cars/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}