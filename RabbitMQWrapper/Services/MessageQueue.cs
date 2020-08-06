using RabbitMQ.Client;
using RabbitMQ.Interfaces;
using RabbitMQ.Models;
using System;
using System.Threading.Channels;

namespace RabbitMQ.Services
{
    public class MessageQueue : IMessageQueue
    {
        private readonly IConnection _connection;
        public IModel Channel { get; protected set; }
        public MessageQueue(IConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.CreateConnection();
            Channel = _connection.CreateModel();
        }

        public MessageQueue(IConnectionFactory connectionFactory, MessageScopeSettings messageScopeSettings) : this(connectionFactory) 
        {
            DeclareExchange(messageScopeSettings.ExchangeName, messageScopeSettings.ExhangeType);
            if (messageScopeSettings.QueueName != null)
            {
                BindQueue(messageScopeSettings.ExchangeName, messageScopeSettings.RoutingKey, messageScopeSettings.QueueName);
            }
        }

        public void DeclareExchange(string exchangeName, string exchangeType) 
        {
            Channel.ExchangeDeclare(exchangeName, exchangeType ?? string.Empty);
        }

        public void BindQueue(string exhangeName, string routingKey, string queueName) 
        {
            Channel.QueueDeclare(queueName, true, false, false);
            Channel.QueueBind(queueName, exhangeName, routingKey);
        }

        public void Dispose() 
        {
            Channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
