using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
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
    public sealed class GetAdminContentAiQueryHandler(IStatisticsRepository statisticsRepository, IArtificialIntelligenceService aiService) : IRequestHandler<GetAdminContentAiQuery, BaseResult<AiSuggestionResult>>
    {
        public async Task<BaseResult<AiSuggestionResult>> Handle(GetAdminContentAiQuery request, CancellationToken cancellationToken)
        {
            var carCount = await statisticsRepository.GetCarCount();
            var brandCount = await statisticsRepository.GetBrandCount();
            var locationCount = await statisticsRepository.GetLocationCount();
            var prompt = $"Admin için içerik/operasyon fikri üret. İçerik türü: {request.ContentType}. Hedef kitle: {request.TargetAudience}. Anahtar kelimeler: {request.Keywords}. Ton: {request.ToneOfVoice}. Platform metrikleri: {carCount} araç, {brandCount} marka, {locationCount} lokasyon.";
            var result = await aiService.GenerateSuggestionAsync(new AiPromptRequest
            {
                UseCase = "Admin İçerik ve Operasyon Asistanı",
                SystemPrompt = "Sen CarBook admin panelinde çalışan pazarlama ve operasyon asistanısın. Türkçe başlık, kısa özet, SEO/CTA ve uygulanabilir maddeler üret.",
                UserPrompt = prompt,
                FallbackTitle = "Admin İçerik Fikri",
                FallbackSuggestions = ["Araç, marka ve lokasyon çeşitliliğini vurgulayan SEO uyumlu bir blog taslağı hazırlayın.", "Kampanya metninde güven, hızlı rezervasyon ve esnek teslimat CTA'larını öne çıkarın.", "Dashboard metriklerine göre lokasyon bazlı performans ve içerik takvimi takip edin."]
            }, cancellationToken);

            return BaseResult<AiSuggestionResult>.Success(result);
        }
    }
}