using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.ContactDtos;

namespace OnionApp.WebUI.Services.ContactServices
{
    public interface IContactService
    {
        Task<BaseResult<List<ResultContactDto>>> GetAllAsync();
        Task<BaseResult<UpdateContactDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateContactDto create);
        Task<BaseResult<object>> UpdateAsync(UpdateContactDto update);
        Task<BaseResult<object>> DeleteAsync(int id);

    }
}
