using RabbitMQ.Client;
using RabbitMQ.Models;
using RabbitMQ.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Interfaces
{
    public interface IMessageConsumerScope
    {
        public IMessageConsumer MessageConsumer{ get; }
    }
}
