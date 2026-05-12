using System.ComponentModel;
using System.Text;
using System.Text.Json;
using CustomerProfileService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace CustomerProfileService.Infrastructure.Messaging;

public class RabbitMqPublisher : IEventPublisher, IAsyncDisposable, IHostedService
{
    private IConnection _connection;
    private IChannel _channel;
    private RabbitMqSettings _settings;
    
    private readonly string _exchangeName = "customer_profile";
    private readonly string _queueName = "customer_profile_events";

    public RabbitMqPublisher(IOptions<RabbitMqSettings> settings)
    {
        _settings = settings.Value;
    }
    
    public async Task PublishAsync<T>(T message, Guid entityId, string eventName)
    {
        if(_channel == null)
            throw new InvalidOperationException("Channel not initialized");
        
        if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException("Exchange (eventName) must be provided.", nameof(eventName));

        var routingKey = eventName;

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        var properties = new BasicProperties
        {
            Persistent = true,
            Type = typeof(T).FullName,
            MessageId = entityId.ToString(),
            Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds()),
        };

        try
        {
            await _channel.QueueBindAsync(
                queue: _queueName,
                exchange: _exchangeName,
                routingKey: routingKey);

            await _channel.BasicPublishAsync(
                exchange: _exchangeName,
                routingKey: routingKey,
                mandatory: true,
                basicProperties: properties,
                body: body);
            
        }
        catch (Exception e)
        {
            throw new InvalidAsynchronousStateException($"Failed to publish event {typeof(T).Name}", e);
        }

    }

    public async ValueTask DisposeAsync()
    {
        if (_channel != null)
        {
            await _channel.CloseAsync();
            _channel.Dispose();
        }
        
        if (_connection != null)
        {
            await _connection.CloseAsync();
            _connection.Dispose();
        }
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var factory = new RabbitMQ.Client.ConnectionFactory()
        {
            HostName = _settings.Host,
            Port = _settings.Port,
            UserName = _settings.Username,
            Password = _settings.Password,
            VirtualHost = "/",
            AutomaticRecoveryEnabled = true,
            NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
        };
        
        _connection =  await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();

        await _channel.ExchangeDeclareAsync(exchange: _exchangeName, type: ExchangeType.Topic, durable: true);
        await _channel.QueueDeclareAsync(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await DisposeAsync();
    }
}