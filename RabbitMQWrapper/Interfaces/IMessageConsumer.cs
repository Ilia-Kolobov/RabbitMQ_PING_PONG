using RabbitMQ.Client.Events;
using RabbitMQ.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Interfaces
{
    public interface IMessageConsumer
    {
        public event EventHandler<BasicDeliverEventArgs> Received;
        public void Connect();
        public void SetAcknowledge(ulong deliveryTag, bool processed);
    }
}
