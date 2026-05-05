using Mapster;
using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.CarPricingQueries;
using OnionApp.Application.Features.Results.CarPricingResults;

namespace OnionApp.Application.Features.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository _repository)
        : IRequestHandler<GetCarPricingWithTimePeriodQuery, BaseResult<List<GetCarPricingWithTimePeriodQueryResut>>>
    {
        public async Task<BaseResult<List<GetCarPricingWithTimePeriodQueryResut>>> Handle(
            GetCarPricingWithTimePeriodQuery request,
            CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithTimePeriod1();

            var mapped = values.Select(x => new GetCarPricingWithTimePeriodQueryResut
            {
                Brand = x.Brand,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,

                // ✅ ARTIK DOĞRU KULLANIM
                DailyAmount = x.DailyAmount,
                WeeklyAmount = x.WeeklyAmount,
                MonthlyAmount = x.MonthlyAmount

            }).ToList();

            return BaseResult<List<GetCarPricingWithTimePeriodQueryResut>>.Success(mapped);
        }
    }
}