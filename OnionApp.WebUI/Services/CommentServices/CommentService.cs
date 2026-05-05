using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.CommentDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _client;

        public CommentService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<List<ResultCommentDto>>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultCommentDto>>>("comments");
        }

        public async Task<BaseResult<UpdateCommentDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<UpdateCommentDto>>($"comments/{id}");
        }

        public async Task<BaseResult<List<ResultGetCommentWithBlogDto>>> GetCommentsByBlogId(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultGetCommentWithBlogDto>>>(
                $"comments/GetCommentWithBlog/{id}");
        }

        public async Task<BaseResult<ResultCommentCountDto>> GetCountCommentByBlogAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<ResultCommentCountDto>>(
                $"comments/GetCommentCount/{id}");
        }

        public async Task<BaseResult<object>> CreateAsync(CreateCommentDto create)
        {
            var response = await _client.PostAsJsonAsync("comments", create);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCommentDto update)
        {
            var response = await _client.PutAsJsonAsync("comments", update);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<object>>();

            return result.IsFailure
                ? throw new ApiValidationException(result.Errors)
                : result;
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"comments/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }
    }
}