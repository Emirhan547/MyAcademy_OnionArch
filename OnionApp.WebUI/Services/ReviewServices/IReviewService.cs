using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.ReviewDtos;

namespace OnionApp.WebUI.Services.ReviewServices
{
    public interface IReviewService
    {
        Task<BaseResult<List<ResultReviewByCarIdDto>>> GetReviewsByCarId(int carId);
        Task<BaseResult<object>> CreateAsync(CreateReviewDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateReviewDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
