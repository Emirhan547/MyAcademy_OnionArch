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
    public class CarFeatureRepository (AppDbContext _context): ICarFeatureRepository
    {
        public async Task ChangeCarFeatureAvailableToFalse(int id)
        {
            var values =await _context.CarFeatures.Where(x => x.Id == id).FirstOrDefaultAsync();
            values.Available = false;
            _context.SaveChanges();
        }

        public async Task ChangeCarFeatureAvailableToTrue(int id)
        {
            var values=await _context.CarFeatures.Where(x => x.Id == id).FirstOrDefaultAsync();
            values.Available = true;
            _context.SaveChanges();

        }

        public async Task CreateCarFeatureByCar(CarFeature feature)
        {
            await _context.CarFeatures.AddAsync(feature);
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarId(int carId)
        {
            return await _context.CarFeatures.Include(y=>y.Feature).Where(x => x.CarId == carId).ToListAsync();
        }
    }
}
