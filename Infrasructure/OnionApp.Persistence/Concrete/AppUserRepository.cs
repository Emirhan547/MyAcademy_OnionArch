using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Contracts;
using OnionApp.Domain.Entities;
using OnionApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Persistence.Concrete
{
    public class AppUserRepository(AppDbContext _context) : IAppUserRepository
    {
        public async Task<AppUser?> GetByFilterUserAsync(Expression<Func<AppUser, bool>> filter)
        {
            return await _context.Set<AppUser>().SingleOrDefaultAsync(filter);
        }

        public async Task<AppRole?> GetByFilterRoleAsync(Expression<Func<AppRole, bool>> filter)
        {
            return await _context.Set<AppRole>().SingleOrDefaultAsync(filter);
        }
    }
}
