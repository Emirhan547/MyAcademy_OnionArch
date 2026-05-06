using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts.AI;
using OnionApp.Application.Features.Queries.AiQueries;
using OnionApp.Application.Features.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AiHandlers
{
    public sealed class GetReservationAssistantAiQueryHandler(IArtificialIntelligenceService aiService) : IRequestHandler<GetReservationAssistantAiQuery, BaseResult<AiSuggestionResult>>
    {
        public async Task<BaseResult<AiSuggestionResult>> Handle(GetReservationAssistantAiQuery request, CancellationToken cancellationToken)
        {
            var prompt = $"Rezervasyon öncesi kontrol listesi ve rota/teslim alma önerileri hazırla. Alış: {request.PickUpLocation} - {request.PickUpDate:dd.MM.yyyy}. İade: {request.DropOffLocation} - {request.ReturnDate:dd.MM.yyyy}. Yaş: {request.Age}. Ehliyet yılı: {request.DriverLicenseYear}. Notlar: {request.TravelNotes}";
            var result = await aiService.GenerateSuggestionAsync(new AiPromptRequest
            {
                UseCase = "Kullanıcı Rezervasyon Asistanı",
                SystemPrompt = "Sen CarBook rezervasyon asistanısın. Türkçe, net ve operasyonel öneriler üret; hukuki kesinlik iddiasında bulunma.",
                UserPrompt = prompt,
                FallbackTitle = "Rezervasyon Hazırlık Planı",
                FallbackSuggestions = ["Alış ve iade saatlerinden önce lokasyon, kimlik ve ehliyet kontrollerini planlayın.", "Depozito, yakıt politikası, kilometre limiti ve sigorta seçeneklerini teslim öncesi doğrulayın.", "İade lokasyonu farklıysa trafik ve teslim prosedürü için ek süre bırakın."]
            }, cancellationToken);

            return BaseResult<AiSuggestionResult>.Success(result);
        }
    }
}
