using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AuthorDtos;
using OnionApp.WebUI.Dtos.BlogDtos;
using System.Reflection.Metadata;

namespace OnionApp.WebUI.Services.BlogServices
{
    public interface IBlogService
    {
        Task<BaseResult<List<ResultLast3BlogsWithAuthorsDto>>> GetAll3LastBlogsWithAuthorsAsync();
        Task<BaseResult<List<ResultAllBlogsWithAuthorDto>>> GetAllBlogsWithAuthorAsync(int? categoryId = null);
        Task<BaseResult<ResultGetBlogByIdDto>> GetByIdAsync(int id);
        Task<BaseResult<List<ResultAuthorByBlogAuthorIdDto>>> GetBlogByAuthorId(int id);
        Task<BaseResult<object>> DeleteAsync(int id);

    }
}
