using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AiDtos;

namespace OnionApp.WebUI.Services.AiServices
{
    public interface IArtificialIntelligenceWebService
    {
        Task<BaseResult<AiSuggestionDto>> GetCarAdvisorAsync(CarAdvisorAiRequestDto request);
        Task<BaseResult<AiSuggestionDto>> GetReservationAssistantAsync(ReservationAssistantAiRequestDto request);
        Task<BaseResult<AiSuggestionDto>> GetAdminContentAsync(AdminContentAiRequestDto request);
    }
}
