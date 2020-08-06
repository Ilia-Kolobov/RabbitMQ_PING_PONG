using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Models
{
    public class MessageProducerSettings
    {
        public IModel Channel { get; set; }
        public PublicationAddress PublicationAddress { get; set; }
    }
}
