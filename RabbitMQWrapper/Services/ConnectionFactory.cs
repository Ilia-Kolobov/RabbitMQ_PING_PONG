using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ.Services
{
    public class ConnectionFactory
    {
        public static RabbitMQ.Client.ConnectionFactory MakeConection() 
        {
            return new RabbitMQ.Client.ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "root",
                Password = "root"
            };
        }
    }  
}
