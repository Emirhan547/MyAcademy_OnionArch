using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Contracts.AI;
using OnionApp.Application.Features.Queries.AiQueries;
using OnionApp.Application.Features.Results;

namespace OnionApp.Application.Features.Handlers.AiHandlers
{
    public sealed class GetSmartCarRankingAiQueryHandler(
        IRentACarRepository rentACarRepository,
        IArtificialIntelligenceService aiService)
        : IRequestHandler<GetSmartCarRankingAiQuery, BaseResult<AiSuggestionResult>>
    {
        public async Task<BaseResult<AiSuggestionResult>> Handle(
            GetSmartCarRankingAiQuery request,
            CancellationToken cancellationToken)
        {
            var availableCars = await rentACarRepository.GetByFilterAsync(
                x => x.LocationId == request.LocationId && x.Available);

            var inventory = string.Join(
                "\n",
                availableCars.Take(12).Select(x =>
                    $"- {x.Car.Brand?.Name} {x.Car.Model}: " +
                    $"{x.Car.Seat} koltuk, " +
                    $"{x.Car.Luggage} bagaj, " +
                    $"{x.Car.Fuel}, " +
                    $"{x.Car.Transmission}, " +
                    $"{x.Car.Km} km"));

            if (string.IsNullOrWhiteSpace(inventory))
            {
                inventory = "Bu lokasyon için uygun araç bulunamadı.";
            }

            var prompt = $"""
                Araç listeleme ekranı için akıllı araç sıralaması oluştur.

                Lokasyon: {request.City}
                Segment Beklentisi: {request.Segment}
                Kullanım Amacı: {request.TripPurpose}
                Yolcu Sayısı: {request.PassengerCount}
                Günlük Bütçe: {request.DailyBudget?.ToString() ?? "belirtilmedi"}
                Ek Notlar: {request.Notes}

                Uygun Araçlar:
                {inventory}

                En uygun 3 aracı sırala ve neden uygun olduklarını açıkla.
                Kısa etiket önerileri ekle.
                Rezervasyon öncesi kısa aksiyon önerisi ver.
                """;

            var result = await aiService.GenerateSuggestionAsync(
                new AiPromptRequest
                {
                    UseCase = "Araç Listeleme Akıllı Sıralama",

                    SystemPrompt = """
                    Sen CarBook araç listeleme sisteminde çalışan AI karar asistanısın.

                    Yanıtları SADECE düz metin olarak üret.

                    Kurallar:
                    - Markdown kullanma
                    - Tablo oluşturma
                    - #, ##, **, |, ---, •, ✅ gibi özel karakterler kullanma
                    - Cevabı kısa ve sade tut
                    - Maksimum 3 araç öner
                    - Her öneriyi numaralandır
                    - Kullanıcıyı başka AI ekranına yönlendirme

                    Cevap formatı şu şekilde olsun:

                    1. Araç Adı
                    Neden uygun olduğu
                    Etiket: Ekonomik / Konfor / Aile / Fırsat

                    2. Araç Adı
                    Neden uygun olduğu
                    Etiket: Konfor / Uzun Yol

                    Sonunda kısa bir rezervasyon önerisi ekle.
                    """,

                    UserPrompt = prompt,

                    FallbackTitle = "AI Akıllı Araç Sıralama",

                    FallbackSuggestions =
                    [
                        "Ekonomik kullanım için düşük yakıt tüketimli araçları değerlendirin.",
                        "Aile kullanımı için geniş bagaj ve yüksek koltuk kapasitesi tercih edin.",
                        "Rezervasyon öncesi teslim lokasyonu ve bütçe detaylarını kontrol edin."
                    ]
                },
                cancellationToken);

            return BaseResult<AiSuggestionResult>.Success(result);
        }
    }
}