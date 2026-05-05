using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.TestimonialDtos;

namespace OnionApp.WebUI.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<BaseResult<List<ResultTestimonialDto>>> GetAllAsync();
        Task<BaseResult<UpdateTestimonialDto>>GetByIdAsync(int id);
        Task <BaseResult<object>>CreateAsync(CreateTestimonialDto create);
        Task <BaseResult<object>>UpdateAsync(UpdateTestimonialDto update);
        Task <BaseResult<object>>DeleteAsync(int id);

    }
}
