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
    public class CarDescriptionRepository (AppDbContext _context): ICarDescriptionRepository
    {
        public async Task<CarDescription> GetCarDescription(int carId)
        {
            return await _context.CarDescriptions.Where(x => x.CarId == carId).FirstOrDefaultAsync();
        }
    }
}
