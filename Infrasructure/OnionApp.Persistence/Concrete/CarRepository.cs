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
    public class CarRepository (AppDbContext _context): ICarRepository
    {
        public async Task <int> GetCarCount()
        {
           return await _context.Cars.CountAsync();
        }

        public async Task<List<Car>> GetCarsListWithBrands()
        {
            var values=await _context.Cars.Include(x => x.Brand).ToListAsync();
            return values;
        }

        public async Task<Car> GetCarWithBrandByIdAsync(int id)
        {
            return await _context.Cars
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Car>> GetLast5CarsWithBrands()
        {
            return await _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.Id).Take(5).ToListAsync();
        }
    }
}
