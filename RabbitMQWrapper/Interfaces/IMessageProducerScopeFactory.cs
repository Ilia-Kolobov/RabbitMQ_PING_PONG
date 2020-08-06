using RabbitMQ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Interfaces
{
    interface IMessageProducerScopeFactory
    {
        public IMessageProducerScope Open(MessageScopeSettings messageScopeSettings);
    }
}
