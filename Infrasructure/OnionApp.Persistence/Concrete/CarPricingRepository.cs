using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Contracts;
using OnionApp.Application.ViewModels;
using OnionApp.Domain.Entities;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Concrete
{
    public class CarPricingRepository(AppDbContext _context) : ICarPricingRepository
    {
        public async Task<List<CarPricing>> GetCarPricingWithCar()
        {
            return await _context.CarPricings
                .Include(x => x.Car)
                .ThenInclude(y => y.Brand)
                .Include(z => z.Pricing)
                .ToListAsync();
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            return await _context.CarPricings
                .Include(x => x.Car)
                .ThenInclude(y => y.Brand)
                .Include(x => x.Pricing)
                .ToListAsync();
        }

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }

        // ✅ NULL-safe decimal helper
        private decimal GetSafeDecimal(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value);
        }

        // ✅ FIXED METHOD
        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            var values = new List<CarPricingViewModel>();

            using var command = _context.Database.GetDbConnection().CreateCommand();

            command.CommandText = @"
                SELECT Model, Name, CoverImageUrl, [2], [3], [4]
                FROM
                (
                    SELECT 
                        Cars.Model, 
                        Brands.Name, 
                        Cars.CoverImageUrl, 
                        CarPricings.PricingId, 
                        CarPricings.Amount 
                    FROM CarPricings 
                    INNER JOIN Cars ON Cars.Id = CarPricings.CarId 
                    INNER JOIN Brands ON Brands.Id = Cars.BrandId
                ) AS SourceTable 
                PIVOT 
                (
                    SUM(Amount) FOR PricingId IN ([2],[3],[4])
                ) AS PivotTable;
            ";

            command.CommandType = System.Data.CommandType.Text;

            _context.Database.OpenConnection();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var item = new CarPricingViewModel
                {
                    Brand = reader["Name"]?.ToString(),
                    Model = reader["Model"]?.ToString(),
                    CoverImageUrl = reader["CoverImageUrl"]?.ToString(),

                    DailyAmount = GetSafeDecimal(reader["2"]),
                    WeeklyAmount = GetSafeDecimal(reader["3"]),
                    MonthlyAmount = GetSafeDecimal(reader["4"])
                };

                values.Add(item);
            }

            _context.Database.CloseConnection();

            return values;
        }
    }
}