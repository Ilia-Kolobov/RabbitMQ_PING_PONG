using RabbitMQ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Interfaces
{
    public interface IMessageConsumerScopeFactory
    {
        public IMessageConsumerScope Open(MessageScopeSettings messageScopeSettings);
        public IMessageConsumerScope Connect(MessageScopeSettings messageScopeSettings);
    }
}
