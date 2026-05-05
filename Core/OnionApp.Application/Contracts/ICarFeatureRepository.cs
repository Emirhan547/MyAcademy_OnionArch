using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>>GetCarFeaturesByCarId(int carId);
        Task ChangeCarFeatureAvailableToFalse(int id);
        Task ChangeCarFeatureAvailableToTrue(int id);
        Task CreateCarFeatureByCar(CarFeature feature);
    }
}
 