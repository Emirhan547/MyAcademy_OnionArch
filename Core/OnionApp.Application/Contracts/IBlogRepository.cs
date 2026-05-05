using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsWithAuthorsAsync();
        Task<List<Blog>> GetAllBlogsWithAuthors();
        Task<List<Blog>> GetBlogByAuthorId(int id);
        Task<List<Blog>> GetBlogsByCategoryId(int categoryId);
    }
}
