using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Interfaces
{
    public interface IMessageProducer
    {
        public void Send(string message, string type = null);
        public void SendType(Type type, string message);
    }
}
