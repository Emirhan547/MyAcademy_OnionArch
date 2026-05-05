using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts
{
    public interface IAppUserRepository
    {
        Task<AppUser?> GetByFilterUserAsync(Expression<Func<AppUser, bool>> filter);
        Task<AppRole?> GetByFilterRoleAsync(Expression<Func<AppRole, bool>> filter);
    }
}
