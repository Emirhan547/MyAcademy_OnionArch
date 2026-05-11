using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionApp.Application.Contracts;
using OnionApp.Application.Contracts.AI;
using OnionApp.Infrastructure.ArtificialIntelligence;
using OnionApp.Infrastructure.Messaging;

namespace OnionApp.Infrastructure.Extensions;

public static class InfrastructureRegistrations
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AiSettings>(configuration.GetSection("AiSettings"));
        services.Configure<RabbitMqSettings>(configuration.GetSection(RabbitMqSettings.SectionName));

        services.AddScoped<IIntegrationEventPublisher, RabbitMqIntegrationEventPublisher>();
        services.AddHttpClient<IArtificialIntelligenceService, ChatCompletionsArtificialIntelligenceService>();
        services.AddScoped<ISmartPricingPredictionService, MlNetSmartPricingPredictionService>();

        return services;
    }
}