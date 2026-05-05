using System.Net.Http.Json;
using System.Text.Json;
using OnionApp.WebUI.Base;

namespace OnionApp.WebUI.Services.StatisticsServices
{
    public class StatisticsService : IStatisticsService
    {
        private readonly HttpClient _client;

        public StatisticsService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("ApiClient");
        }

        public Task<BaseResult<int>> GetCarCount()
    => GetAsync<int>("statistics/GetCarCount");

        public Task<BaseResult<int>> GetLocationCount()
            => GetAsync<int>("statistics/GetLocationCount");

        public Task<BaseResult<int>> GetAuthorCount()
            => GetAsync<int>("statistics/GetAuthorCount");

        public Task<BaseResult<int>> GetBlogCount()
            => GetAsync<int>("statistics/GetBlogCount");

        public Task<BaseResult<int>> GetBrandCount()
            => GetAsync<int>("statistics/GetBrandCount");

        public Task<BaseResult<decimal>> GetAvgRentPriceForDaily()
            => GetAsync<decimal>("statistics/GetAvgRentPriceForDaily");

        public Task<BaseResult<decimal>> GetAvgRentPriceForWeekly()
            => GetAsync<decimal>("statistics/GetAvgRentPriceForWeekly");

        public Task<BaseResult<decimal>> GetAvgRentPriceForMonthly()
            => GetAsync<decimal>("statistics/GetAvgRentPriceForMonthly");

        public Task<BaseResult<int>> GetCarCountByTranmissionIsAuto()
            => GetAsync<int>("statistics/GetCarCountByTranmissionIsAuto");

        public Task<BaseResult<string>> GetBrandNameByMaxCar()
            => GetAsync<string>("statistics/GetBrandNameByMaxCar");

        public Task<BaseResult<string>> GetBlogTitleByMaxBlogComment()
            => GetAsync<string>("statistics/GetBlogTitleByMaxBlogComment");

        public Task<BaseResult<int>> GetCarCountByKmSmallerThen1000()
            => GetAsync<int>("statistics/GetCarCountByKmSmallerThen1000");

        public Task<BaseResult<int>> GetCarCountByFuelGasolineOrDiesel()
            => GetAsync<int>("statistics/GetCarCountByFuelGasolineOrDiesel");

        public Task<BaseResult<int>> GetCarCountByFuelElectric()
            => GetAsync<int>("statistics/GetCarCountByFuelElectric");

        public Task<BaseResult<string>> GetCarBrandAndModelByRentPriceDailyMax()
            => GetAsync<string>("statistics/GetCarBrandAndModelByRentPriceDailyMax");

        public Task<BaseResult<string>> GetCarBrandAndModelByRentPriceDailyMin()
            => GetAsync<string>("statistics/GetCarBrandAndModelByRentPriceDailyMin");

        private async Task<BaseResult<T>> GetAsync<T>(string url)
        {
            var result = await _client.GetFromJsonAsync<BaseResult<T>>(url);

            if (result == null)
                throw new Exception("Deserialize hatası");

            return result;
        }
    }
}