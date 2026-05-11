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
               SELECT 
                    c.Model,
                    b.Name,
                    c.CoverImageUrl,
                    SUM(CASE WHEN p.Name = N'Günlük' THEN cp.Amount ELSE 0 END) AS DailyAmount,
                    SUM(CASE WHEN p.Name = N'Haftalık' THEN cp.Amount ELSE 0 END) AS WeeklyAmount,
                    SUM(CASE WHEN p.Name = N'Aylık' THEN cp.Amount ELSE 0 END) AS MonthlyAmount
                FROM CarPricings cp
                INNER JOIN Cars c ON c.Id = cp.CarId
                INNER JOIN Brands b ON b.Id = c.BrandId
                INNER JOIN Pricings p ON p.Id = cp.PricingId
                GROUP BY c.Id, c.Model, b.Name, c.CoverImageUrl;
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

                    DailyAmount = GetSafeDecimal(reader["DailyAmount"]),
                    WeeklyAmount = GetSafeDecimal(reader["WeeklyAmount"]),
                    MonthlyAmount = GetSafeDecimal(reader["MonthlyAmount"])
                };

                values.Add(item);
            }

            _context.Database.CloseConnection();

            return values;
        }
    }
}