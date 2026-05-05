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
    public class ReviewRepository(AppDbContext _context) : IReviewRepository
    {
        public async Task<List<Review>> GetReviewsByCarId(int carId)
        {
            return await _context.Reviews.Where(x => x.CarId == carId).ToListAsync();
        }
    }
}
