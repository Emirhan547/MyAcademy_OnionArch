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
    public sealed class GetCarAdvisorAiQueryHandler(ICarRepository carRepository, IArtificialIntelligenceService aiService) : IRequestHandler<GetCarAdvisorAiQuery, BaseResult<AiSuggestionResult>>
    {
        public async Task<BaseResult<AiSuggestionResult>> Handle(GetCarAdvisorAiQuery request, CancellationToken cancellationToken)
        {
            var cars = await carRepository.GetCarsListWithBrands();
            var inventory = string.Join("\n", cars.Take(20).Select(x => $"- {x.Brand?.Name} {x.Model}: {x.Seat} koltuk, {x.Luggage} bagaj, {x.Fuel}, {x.Transmission}, {x.Km} km"));
            var prompt = $"Kullanıcının araç kiralama ihtiyacına göre en uygun 3 aracı ve nedenlerini öner.\nAmaç: {request.TripPurpose}\nYolcu: {request.PassengerCount}\nGünlük bütçe: {request.DailyBudget?.ToString() ?? "belirtilmedi"}\nYakıt: {request.PreferredFuel}\nVites: {request.PreferredTransmission}\nNotlar: {request.Notes}\nMevcut araçlar:\n{inventory}";

            var result = await aiService.GenerateSuggestionAsync(new AiPromptRequest
            {
                UseCase = "Kullanıcı Araç Danışmanı",
                SystemPrompt = "Sen CarBook için Türkçe konuşan, kısa ve uygulanabilir araç kiralama danışmanısın. Yanıtı başlık, özet ve maddeler halinde ver.",
                UserPrompt = prompt,
                FallbackTitle = "Akıllı Araç Önerisi",
                FallbackSuggestions = ["Yolcu ve bagaj sayısına göre koltuk/bagaj kapasitesi yüksek aracı seçin.", "Şehir içi kullanımda düşük km ve otomatik vites konfor sağlar.", "Uzun yol için yakıt tipi, teslim lokasyonu ve günlük bütçeyi birlikte değerlendirin."]
            }, cancellationToken);

            return BaseResult<AiSuggestionResult>.Success(result);
        }
    }
}
