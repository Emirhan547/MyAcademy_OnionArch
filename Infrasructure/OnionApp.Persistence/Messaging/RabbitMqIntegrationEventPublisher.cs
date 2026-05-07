using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using OnionApp.Application.Contracts;
using RabbitMQ.Client;

namespace OnionApp.Persistence.Messaging;

public class RabbitMqIntegrationEventPublisher : IIntegrationEventPublisher
{
    private readonly RabbitMqSettings _settings;

    public RabbitMqIntegrationEventPublisher(IOptions<RabbitMqSettings> options)
    {
        _settings = options.Value;
    }

    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
    {
        var factory = new ConnectionFactory
        {
            HostName = _settings.HostName,
            Port = _settings.Port,
            UserName = _settings.UserName,
            Password = _settings.Password,
            VirtualHost = _settings.VirtualHost
        };

        await using var connection = await factory.CreateConnectionAsync(cancellationToken);
        await using var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);

        await channel.ExchangeDeclareAsync(_settings.ExchangeName, ExchangeType.Topic, durable: true, cancellationToken: cancellationToken);

        var eventName = typeof(TEvent).Name;
        var routingKey = eventName.Replace("IntegrationEvent", string.Empty).ToLowerInvariant();
        var payload = JsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(payload);

        var properties = new BasicProperties
        {
            Persistent = true,
            ContentType = "application/json",
            Type = eventName
        };

        await channel.BasicPublishAsync(
            exchange: _settings.ExchangeName,
            routingKey: routingKey,
            mandatory: false,
            basicProperties: properties,
            body: body,
            cancellationToken: cancellationToken);
    }
}