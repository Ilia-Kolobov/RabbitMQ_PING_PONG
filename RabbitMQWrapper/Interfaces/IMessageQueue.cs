using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Interfaces
{
    interface IMessageQueue : IDisposable
    {
        public IModel Channel { get; }
        public void DeclareExchange(string exchangeName, string exchangeType);
        public void BindQueue(string exhangeName, string routingKey, string queueName);
    }
}
