using MediatR;
using OnionApp.Application.Base;
using OnionApp.Application.Contracts.AI;
using OnionApp.Application.Features.Queries.AiQueries;
using OnionApp.Application.Features.Results;

namespace OnionApp.Application.Features.Handlers.AiHandlers
{
    public sealed class GetReservationAssistantAiQueryHandler(
        IArtificialIntelligenceService aiService)
        : IRequestHandler<GetReservationAssistantAiQuery, BaseResult<AiSuggestionResult>>
    {
        public async Task<BaseResult<AiSuggestionResult>> Handle(
            GetReservationAssistantAiQuery request,
            CancellationToken cancellationToken)
        {
            var prompt = $"""
                Rezervasyon formunu analiz et ve operasyon kontrolü yap.

                Alış Lokasyonu: {request.PickUpLocation}
                Alış Tarihi: {request.PickUpDate:dd.MM.yyyy}

                İade Lokasyonu: {request.DropOffLocation}
                İade Tarihi: {request.ReturnDate:dd.MM.yyyy}

                Yaş: {request.Age}
                Ehliyet Yılı: {request.DriverLicenseYear}

                Ek Notlar:
                {request.TravelNotes}

                Riskleri, eksik bilgileri ve teslim günü dikkat edilmesi gereken noktaları değerlendir.
                """;

            var result = await aiService.GenerateSuggestionAsync(
                new AiPromptRequest
                {
                    UseCase = "Kullanıcı Rezervasyon Asistanı",

                    SystemPrompt = """
                    Sen CarBook rezervasyon sisteminde çalışan operasyon kontrol asistanısın.

                    Yanıtları SADECE düz metin olarak üret.

                    Kurallar:
                    - Markdown kullanma
                    - Tablo oluşturma
                    - #, ##, **, |, ---, •, ✅ gibi özel karakterler kullanma
                    - Hukuki kesinlik belirtme
                    - Kısa ve net yaz
                    - Maksimum 5 kısa madde oluştur
                    - Her maddeyi numaralandır

                    Cevap formatı şu şekilde olsun:

                    1. Risk veya kontrol bilgisi
                    Açıklama

                    2. Risk veya kontrol bilgisi
                    Açıklama
                    """,

                    UserPrompt = prompt,

                    FallbackTitle = "AI Rezervasyon Risk Kontrolü",

                    FallbackSuggestions =
                    [
                        "Teslim öncesinde kimlik ve ehliyet bilgilerini doğrulayın.",
                        "Depozito ve sigorta detaylarını müşteriye tekrar hatırlatın.",
                        "Farklı iade lokasyonlarında trafik ve teslim süresini önceden planlayın."
                    ]
                },
                cancellationToken);

            return BaseResult<AiSuggestionResult>.Success(result);
        }
    }
}