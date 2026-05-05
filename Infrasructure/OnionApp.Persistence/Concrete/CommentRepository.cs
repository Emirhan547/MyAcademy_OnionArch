using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Results.CommentResults;
using OnionApp.Domain.Entities;
using OnionApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Persistence.Concrete
{
    public class CommentRepository(AppDbContext _context) : ICommentRepository
    {
        public async Task<List<Comment>> GetCommentsByBlogId(int id)
        {
            return await _context.Comments.Where(x => x.BlogId == id).ToListAsync();

        }

        public int GetCountCommentByBlog(int id)
        {
            return _context.Comments.Where(x => x.BlogId == id).Count();

        }
    }
}
