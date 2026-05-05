using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrands();
        Task<List<Car>>GetLast5CarsWithBrands();
        Task<Car> GetCarWithBrandByIdAsync(int id);
        Task<int> GetCarCount();
    }
}
