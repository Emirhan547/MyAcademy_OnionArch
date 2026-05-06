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
    public sealed class GetSmartCarRankingAiQueryHandler(IRentACarRepository rentACarRepository, IArtificialIntelligenceService aiService) : IRequestHandler<GetSmartCarRankingAiQuery, BaseResult<AiSuggestionResult>>
    {
        public async Task<BaseResult<AiSuggestionResult>> Handle(GetSmartCarRankingAiQuery request, CancellationToken cancellationToken)
        {
            var availableCars = await rentACarRepository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available);
            var inventory = string.Join("\n", availableCars.Take(12).Select(x => $"- {x.Car.Brand?.Name} {x.Car.Model}: {x.Car.Seat} koltuk, {x.Car.Luggage} bagaj, {x.Car.Fuel}, {x.Car.Transmission}, {x.Car.Km} km"));

            if (string.IsNullOrWhiteSpace(inventory))
            {
                inventory = "Bu lokasyon için uygun araç listesi boş görünüyor.";
            }

            var prompt = $"Araç listeleme ekranında gösterilecek akıllı sıralama ve kısa etiket önerileri üret. Lokasyon: {request.City}. Segment beklentisi: {request.Segment}. Kullanım amacı: {request.TripPurpose}. Yolcu sayısı: {request.PassengerCount}. Günlük bütçe: {request.DailyBudget?.ToString() ?? "belirtilmedi"}. Notlar: {request.Notes}. Mevcut uygun araçlar:\n{inventory}\nYanıtında en uygun 3 aracı nedenleriyle sırala, fırsat/ekonomik/konfor/aile gibi kısa etiketler öner ve rezervasyon öncesi bir aksiyon cümlesi ekle.";

            var result = await aiService.GenerateSuggestionAsync(new AiPromptRequest
            {
                UseCase = "Araç Listeleme Akıllı Sıralama",
                SystemPrompt = "Sen CarBook araç listeleme akışına gömülü çalışan Türkçe AI karar asistanısın. Cevabı kısa tut; araç adı, neden, etiket ve aksiyon maddeleri halinde üret. Kullanıcıyı ayrı AI sayfasına yönlendirme.",
                UserPrompt = prompt,
                FallbackTitle = "AI Akıllı Araç Sıralama",
                FallbackSuggestions = ["Ekonomik kullanım için düşük yakıt tüketimli ve düşük kilometreli araçları öne alın.", "Aile ve uzun yol kullanımında koltuk, bagaj ve otomatik vites kriterlerini birlikte değerlendirin.", "Rezervasyona geçmeden önce teslim lokasyonu, iade tarihi ve günlük bütçeyi kontrol edin."]
            }, cancellationToken);

            return BaseResult<AiSuggestionResult>.Success(result);
        }
    }
}