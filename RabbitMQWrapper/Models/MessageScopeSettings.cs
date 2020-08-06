using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Models
{
    public class MessageScopeSettings
    {
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
        public string ExhangeType { get; set; }
    }
}
