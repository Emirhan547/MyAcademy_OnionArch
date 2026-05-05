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
    public class TagCloudRepository(AppDbContext _context) : ITagCloudRepository
    {
        public async Task<List<TagCloud>> GetTagCloudsByBlogId(int id)
        {
            return await _context.TagClouds.Where(x=>x.BlogId==id).ToListAsync();
        }
    }
}
