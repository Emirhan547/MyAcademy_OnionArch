using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.ReviewDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly HttpClient _client;

        public ReviewService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateReviewDto create)
        {
            var response = await _client.PostAsJsonAsync("reviews", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"reviews/{id}");
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<List<ResultReviewByCarIdDto>>> GetReviewsByCarId(int carId)
        {
            return await _client
                .GetFromJsonAsync<BaseResult<List<ResultReviewByCarIdDto>>>($"reviews/{carId}");
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateReviewDto update)
        {
            var response = await _client.PutAsJsonAsync("reviews", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }
    }
}