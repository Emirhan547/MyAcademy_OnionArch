using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AuthorDtos;
using OnionApp.WebUI.Dtos.BlogDtos;
using OnionApp.WebUI.Exceptions;
using System.Net.Http.Json;

namespace OnionApp.WebUI.Services.BlogServices
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _client;

        public BlogService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"blogs/{id}");
            return await response.Content.ReadFromJsonAsync<BaseResult<object>>();
        }

        public async Task<BaseResult<List<ResultLast3BlogsWithAuthorsDto>>> GetAll3LastBlogsWithAuthorsAsync()
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultLast3BlogsWithAuthorsDto>>>("blogs/GetLast3BlogsWithAuthors");
        }

        public async Task<BaseResult<List<ResultAllBlogsWithAuthorDto>>> GetAllBlogsWithAuthorAsync(int? categoryId = null)
        {
            var endpoint = categoryId.HasValue
                ? $"blogs/GetAllBlogsWithAuthor?categoryId={categoryId.Value}"
                : "blogs/GetAllBlogsWithAuthor";

            return await _client.GetFromJsonAsync<BaseResult<List<ResultAllBlogsWithAuthorDto>>>(endpoint);
        }

        public async Task<BaseResult<List<ResultAuthorByBlogAuthorIdDto>>> GetBlogByAuthorId(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<List<ResultAuthorByBlogAuthorIdDto>>>($"blogs/GetBlogByAuthorId?id={id}");
        }

        public async Task<BaseResult<ResultGetBlogByIdDto>> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<BaseResult<ResultGetBlogByIdDto>>($"blogs/{id}");
        }
    }
}