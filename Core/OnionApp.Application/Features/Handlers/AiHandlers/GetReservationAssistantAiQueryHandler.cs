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
            var prompt = $"Rezervasyon formunun iş akışı içinde risk, eksik bilgi ve operasyon kontrolü yap. Alış: {request.PickUpLocation} - {request.PickUpDate:dd.MM.yyyy}. İade: {request.DropOffLocation} - {request.ReturnDate:dd.MM.yyyy}. Yaş: {request.Age}. Ehliyet yılı: {request.DriverLicenseYear}. Notlar: {request.TravelNotes}. Yanıtında risk seviyesi, eksik/tamamlanması gereken bilgiler, müşteriyle teyit edilecek maddeler ve teslim günü hazırlık adımları olsun.";
            var result = await aiService.GenerateSuggestionAsync(new AiPromptRequest
            {
                UseCase = "Kullanıcı Rezervasyon Asistanı",
                SystemPrompt = "Sen CarBook rezervasyon formunun içinde çalışan Türkçe operasyon kontrol asistanısın. Kısa, net ve iş akışına uygun risk/eksik bilgi maddeleri üret; hukuki kesinlik iddiasında bulunma.",
                UserPrompt = prompt,
                FallbackTitle = "AI Rezervasyon Risk Kontrolü",
                FallbackSuggestions = ["Alış ve iade saatlerinden önce lokasyon, kimlik ve ehliyet kontrollerini planlayın.", "Depozito, yakıt politikası, kilometre limiti ve sigorta seçeneklerini teslim öncesi doğrulayın.", "İade lokasyonu farklıysa trafik ve teslim prosedürü için ek süre bırakın."]
            }, cancellationToken);

            return BaseResult<AiSuggestionResult>.Success(result);
        }
    }
}
