using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts;
using OnionApp.Application.Contracts.AI;
using OnionApp.Application.Features.Queries.AiQueries;
using OnionApp.Application.Features.Results;

namespace OnionApp.Application.Features.Handlers.AiHandlers
{
    public sealed class GetCarAdvisorAiQueryHandler(
        ICarRepository carRepository,
        IArtificialIntelligenceService aiService)
        : IRequestHandler<GetCarAdvisorAiQuery, BaseResult<AiSuggestionResult>>
    {
        public async Task<BaseResult<AiSuggestionResult>> Handle(
            GetCarAdvisorAiQuery request,
            CancellationToken cancellationToken)
        {
            var cars = await carRepository.GetCarsListWithBrands();

            var inventory = string.Join(
                "\n",
                cars.Take(20).Select(x =>
                    $"- {x.Brand?.Name} {x.Model}: " +
                    $"{x.Seat} koltuk, " +
                    $"{x.Luggage} bagaj, " +
                    $"{x.Fuel}, " +
                    $"{x.Transmission}, " +
                    $"{x.Km} km"));

            var prompt = $"""
                Kullanıcının araç kiralama ihtiyacına göre en uygun 3 aracı öner.

                Amaç: {request.TripPurpose}
                Yolcu Sayısı: {request.PassengerCount}
                Günlük Bütçe: {request.DailyBudget?.ToString() ?? "belirtilmedi"}
                Yakıt Tercihi: {request.PreferredFuel}
                Vites Tercihi: {request.PreferredTransmission}
                Ek Notlar: {request.Notes}

                Mevcut Araçlar:
                {inventory}
                """;

            var result = await aiService.GenerateSuggestionAsync(
                new AiPromptRequest
                {
                    UseCase = "Kullanıcı Araç Danışmanı",

                    SystemPrompt = """
                    Sen CarBook için çalışan profesyonel araç kiralama danışmanısın.

                    Yanıtları SADECE düz metin olarak üret.

                    Kurallar:
                    - Markdown kullanma
                    - Tablo oluşturma
                    - #, ##, **, |, ---, •, ✅ gibi özel karakterler kullanma
                    - Kısa ve sade yaz
                    - Maksimum 3 araç öner
                    - Her araç önerisini numaralandır

                    Cevap formatı şu şekilde olsun:

                    1. Araç Adı
                    Neden uygun olduğu

                    2. Araç Adı
                    Neden uygun olduğu
                    """,

                    UserPrompt = prompt,

                    FallbackTitle = "Akıllı Araç Önerisi",

                    FallbackSuggestions =
                    [
                        "Yolcu ve bagaj sayısına göre geniş araç tercih edin.",
                        "Şehir içi kullanım için otomatik vites ve düşük yakıt tüketimi avantaj sağlar.",
                        "Uzun yol kullanımında konfor ve bagaj kapasitesi önemlidir."
                    ]
                },
                cancellationToken);

            return BaseResult<AiSuggestionResult>.Success(result);
        }
    }
}