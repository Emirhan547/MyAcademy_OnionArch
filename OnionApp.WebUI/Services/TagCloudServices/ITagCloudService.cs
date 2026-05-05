using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.BlogDtos;
using OnionApp.WebUI.Dtos.TagCloudDtos;

namespace OnionApp.WebUI.Services.TagCloudServices
{
    public interface ITagCloudService
    {
        Task<BaseResult<List<ResultTagCloudDto>>> GetAllAsync();
        Task<BaseResult<UpdateTagCloudDto>>GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateTagCloudDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateTagCloudDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<List<ResultGetByBlogIdTagCloudDto>>> GetTagCloudById(int id);

    }
}