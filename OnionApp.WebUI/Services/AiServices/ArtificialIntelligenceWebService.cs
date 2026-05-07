using System.Net.Http.Json;
using OnionApp.WebUI.Base;
using OnionApp.WebUI.Dtos.AiDtos;

namespace OnionApp.WebUI.Services.AiServices
{
    public sealed class ArtificialIntelligenceWebService(IHttpClientFactory factory) : IArtificialIntelligenceWebService
    {
        private readonly HttpClient _client = factory.CreateClient("ApiClient");

        public async Task<BaseResult<AiSuggestionDto>> GetCarAdvisorAsync(CarAdvisorAiRequestDto request)
        {
            return await PostAsync<CarAdvisorAiRequestDto, AiSuggestionDto>("ArtificialIntelligence/car-advisor", request);
        }
        public async Task<BaseResult<AiSuggestionDto>> GetSmartCarRankingAsync(SmartCarRankingAiRequestDto request)
        {
            return await PostAsync<SmartCarRankingAiRequestDto, AiSuggestionDto>("ArtificialIntelligence/smart-car-ranking", request);
        }
        public async Task<BaseResult<SmartPricingDto>> GetSmartPricingAsync(SmartPricingAiRequestDto request)
        {
            return await PostAsync<SmartPricingAiRequestDto, SmartPricingDto>("ArtificialIntelligence/smart-pricing", request);
        }
        public async Task<BaseResult<AiSuggestionDto>> GetReservationAssistantAsync(ReservationAssistantAiRequestDto request)
        {
            return await PostAsync<ReservationAssistantAiRequestDto, AiSuggestionDto>("ArtificialIntelligence/reservation-assistant", request);
        }

        public async Task<BaseResult<AiSuggestionDto>> GetAdminContentAsync(AdminContentAiRequestDto request)
        {
            return await PostAsync<AdminContentAiRequestDto, AiSuggestionDto>("ArtificialIntelligence/admin-content", request);
        }

        private async Task<BaseResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var response = await _client.PostAsJsonAsync(url, request);
            var result = await response.Content.ReadFromJsonAsync<BaseResult<TResponse>>();
            return result ?? new BaseResult<TResponse>
            {
                Errors = new() { new Error { ErrorMessage = "AI servisi yanıtı okunamadı." } }
            };
        }
    }
}