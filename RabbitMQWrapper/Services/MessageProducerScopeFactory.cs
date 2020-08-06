using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Interfaces;
using RabbitMQ.Models;

namespace RabbitMQ.Services
{
    public class MessageProducerScopeFactory : IMessageProducerScopeFactory
    {
        private readonly IConnectionFactory _connectionFactory;

        public MessageProducerScopeFactory(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IMessageProducerScope Open(MessageScopeSettings messageScopeSettings)
        {
            return new MessageProducerScope(_connectionFactory, messageScopeSettings);
        }
    }
}
