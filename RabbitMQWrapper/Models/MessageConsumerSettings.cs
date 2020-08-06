using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Models
{
    public class MessageConsumerSettings
    {
        public bool SequentialFetch { get; set; } = true;
        public bool AutoAcknoledge { get; set; } = false;
        public IModel Channel { get; set; }
        public string QueueName { get; set; }
    }
}
