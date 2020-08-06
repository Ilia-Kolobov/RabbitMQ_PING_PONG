using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Interfaces
{
    public interface IMessageProducerScope
    {
        public IMessageProducer MessageProducer { get; }
    }
}