using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AboutDtos;
using OnionApp.WebUI.Dtos.AuthorDtos;

namespace OnionApp.WebUI.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task<BaseResult<List<ResultAuthorDto>>> GetAllAsync();
        Task<BaseResult<UpdateAuthorDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAuthorDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateAuthorDto update);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
