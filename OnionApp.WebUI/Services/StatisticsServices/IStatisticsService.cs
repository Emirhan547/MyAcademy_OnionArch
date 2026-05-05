using OnionApp.WebUI.Base;

namespace OnionApp.WebUI.Services.StatisticsServices
{
    public interface IStatisticsService
    {
        Task<BaseResult<int>> GetCarCount();
        Task<BaseResult<int>> GetLocationCount();
        Task<BaseResult<int>> GetAuthorCount();
        Task<BaseResult<int>> GetBlogCount();
        Task<BaseResult<int>> GetBrandCount();

        Task<BaseResult<decimal>> GetAvgRentPriceForDaily();
        Task<BaseResult<decimal>> GetAvgRentPriceForWeekly();
        Task<BaseResult<decimal>> GetAvgRentPriceForMonthly();

        Task<BaseResult<int>> GetCarCountByTranmissionIsAuto();

        Task<BaseResult<string>> GetBrandNameByMaxCar();
        Task<BaseResult<string>> GetBlogTitleByMaxBlogComment();

        Task<BaseResult<int>> GetCarCountByKmSmallerThen1000();
        Task<BaseResult<int>> GetCarCountByFuelGasolineOrDiesel();
        Task<BaseResult<int>> GetCarCountByFuelElectric();

        Task<BaseResult<string>> GetCarBrandAndModelByRentPriceDailyMax();
        Task<BaseResult<string>> GetCarBrandAndModelByRentPriceDailyMin();
    }
}
