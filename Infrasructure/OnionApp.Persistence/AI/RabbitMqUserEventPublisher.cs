using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnionApp.Application.AI.Models;
using OnionApp.Application.AI.Services;
using RabbitMQ.Client;

namespace OnionApp.Persistence.AI;

public sealed class RabbitMqUserEventPublisher : IUserEventPublisher
{
    private readonly RabbitMqOptions _options;
    private readonly ILogger<RabbitMqUserEventPublisher> _logger;

    public RabbitMqUserEventPublisher(IOptions<RabbitMqOptions> options, ILogger<RabbitMqUserEventPublisher> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public Task PublishAsync(UserEventMessage message, CancellationToken cancellationToken = default)
    {
        var factory = new ConnectionFactory
        {
            HostName = _options.HostName,
            Port = _options.Port,
            UserName = _options.UserName,
            Password = _options.Password
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.ExchangeDeclare(_options.ExchangeName, ExchangeType.Topic, durable: true, autoDelete: false);

        var payload = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(payload);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;
        properties.CorrelationId = message.CorrelationId;
        properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        properties.MessageId = Guid.NewGuid().ToString("N");

        channel.BasicPublish(_options.ExchangeName, _options.RoutingKey, properties, body);

        _logger.LogInformation("Published user event {EventType} for user {UserId} with correlation {CorrelationId}",
            message.EventType, message.UserId, message.CorrelationId);

        return Task.CompletedTask;
    }
}