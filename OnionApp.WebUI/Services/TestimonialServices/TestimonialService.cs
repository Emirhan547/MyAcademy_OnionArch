using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.TestimonialDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly HttpClient _client;

        public TestimonialService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultTestimonialDto>>> GetAllAsync()
        {
            return await _client
                .GetFromJsonAsync<BaseResult<List<ResultTestimonialDto>>>("testimonials");
        }

        public async Task<BaseResult<UpdateTestimonialDto>> GetByIdAsync(int id)
        {
            return await _client
                .GetFromJsonAsync<BaseResult<UpdateTestimonialDto>>($"testimonials/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateTestimonialDto create)
        {
            var response = await _client.PostAsJsonAsync("testimonials", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTestimonialDto update)
        {
            var response = await _client.PutAsJsonAsync("testimonials", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"testimonials/{id}");
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }
    }
}