using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Contracts;
using OnionApp.Persistence.Context;

namespace OnionApp.Persistence.Concrete
{
    public class StatisticsRepository(AppDbContext _context) : IStatisticsRepository
    {
        public async Task<int> GetCarCount()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetLocationCount()
        {
            return await _context.Locations.CountAsync();
        }

        public async Task<int> GetAuthorCount()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<int> GetBlogCount()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<int> GetBrandCount()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<decimal> GetAvgRentPriceForDaily()
        {
            int id = await _context.Pricings
                .Where(x => x.Name == "Günlük")
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            return await _context.CarPricings
                .Where(x => x.PricingId == id)
                .AverageAsync(x => x.Amount);
        }

        public async Task<decimal> GetAvgRentPriceForWeekly()
        {
            int id = await _context.Pricings
                .Where(x => x.Name == "Haftalık")
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            return await _context.CarPricings
                .Where(x => x.PricingId == id)
                .AverageAsync(x => x.Amount);
        }

        public async Task<decimal> GetAvgRentPriceForMonthly()
        {
            int id = await _context.Pricings
                .Where(x => x.Name == "Aylık")
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            return await _context.CarPricings
                .Where(x => x.PricingId == id)
                .AverageAsync(x => x.Amount);
        }

        public async Task<int> GetCarCountByTranmissionIsAuto()
        {
            return await _context.Cars
                .Where(x => x.Transmission == "Otomatik")
                .CountAsync();
        }

        public async Task<string> GetBrandNameByMaxCar()
        {
            var value = await _context.Cars
                .GroupBy(x => x.BrandId)
                .Select(g => new
                {
                    BrandId = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .FirstOrDefaultAsync();

            if (value == null) return string.Empty;

            return await _context.Brands
                .Where(x => x.Id == value.BrandId)
                .Select(x => x.Name)
                .FirstOrDefaultAsync();
        }

        public async Task<string> GetBlogTitleByMaxBlogComment()
        {
            var value = await _context.Comments
                .GroupBy(x => x.BlogId)
                .Select(g => new
                {
                    BlogId = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .FirstOrDefaultAsync();

            if (value == null) return string.Empty;

            return await _context.Blogs
                .Where(x => x.Id == value.BlogId)
                .Select(x => x.Title)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetCarCountByKmSmallerThen1000()
        {
            return await _context.Cars
                .Where(x => x.Km <= 1000)
                .CountAsync();
        }

        public async Task<int> GetCarCountByFuelGasolineOrDiesel()
        {
            return await _context.Cars
                .Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel")
                .CountAsync();
        }

        public async Task<int> GetCarCountByFuelElectric()
        {
            return await _context.Cars
                .Where(x => x.Fuel == "Elektrik")
                .CountAsync();
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            int pricingId = await _context.Pricings
                .Where(x => x.Name == "Günlük")
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            decimal maxAmount = await _context.CarPricings
                .Where(x => x.PricingId == pricingId)
                .MaxAsync(x => x.Amount);

            int carId = await _context.CarPricings
                .Where(x => x.Amount == maxAmount)
                .Select(x => x.CarId)
                .FirstOrDefaultAsync();

            return await _context.Cars
                .Where(x => x.Id == carId)
                .Include(x => x.Brand)
                .Select(x => x.Brand.Name + " " + x.Model)
                .FirstOrDefaultAsync();
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = await _context.Pricings
                .Where(x => x.Name == "Günlük")
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            decimal minAmount = await _context.CarPricings
                .Where(x => x.PricingId == pricingId)
                .MinAsync(x => x.Amount);

            int carId = await _context.CarPricings
                .Where(x => x.Amount == minAmount)
                .Select(x => x.CarId)
                .FirstOrDefaultAsync();

            return await _context.Cars
                .Where(x => x.Id == carId)
                .Include(x => x.Brand)
                .Select(x => x.Brand.Name + " " + x.Model)
                .FirstOrDefaultAsync();
        }
    }
}