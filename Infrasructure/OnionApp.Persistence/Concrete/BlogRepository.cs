using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Contracts;
using OnionApp.Domain.Entities;
using OnionApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Persistence.Concrete
{
    public class BlogRepository(AppDbContext _context) : IBlogRepository
    {
        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {
            return await _context.Blogs.Include(x => x.Author).Include(x => x.Category).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogByAuthorId(int id)
        {
            return await _context.Blogs.Include(x => x.Author).Include(x => x.Category).Where(y => y.AuthorId == id).ToListAsync();
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthorsAsync()
        {
            return await _context.Blogs.Include(x => x.Author).OrderByDescending(x=>x.Id).Take(3).ToListAsync();
        }
        public async Task<List<Blog>> GetBlogsByCategoryId(int categoryId)
        {
            return await _context.Blogs
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }
    }
}
