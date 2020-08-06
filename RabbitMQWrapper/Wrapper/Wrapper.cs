using System;
using System.Linq;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Interfaces;
using RabbitMQ.Models;
using RabbitMQ.Services;

namespace RabbitMQ.Wrapper
{
    public class Wrapper
    {
        private readonly IMessageProducerScope _messageProducerScope;
        private readonly IMessageConsumerScope _messageConsumerScope;

        public Wrapper(string exchangeNameForProducer, string queueNameForProducer, string routingKeyForProducer, string exchangeNameForConsumer, string queueNameForConsumer, string routingKeyForConsumer)
        {
            IMessageProducerScopeFactory messageProducerScopeFactory = new MessageProducerScopeFactory(Services.ConnectionFactory.MakeConection());
            _messageProducerScope = messageProducerScopeFactory.Open(new MessageScopeSettings
            {
                ExchangeName = exchangeNameForProducer,
                ExhangeType = ExchangeType.Direct,
                QueueName = queueNameForProducer,
                RoutingKey = routingKeyForProducer
            });
            IMessageConsumerScopeFactory messageConsumerScopeFactory = new MessageConsumerScopeFactory(Services.ConnectionFactory.MakeConection());

            _messageConsumerScope = messageConsumerScopeFactory.Connect(new MessageScopeSettings
            {
                ExchangeName = exchangeNameForConsumer,
                ExhangeType = ExchangeType.Direct,
                QueueName = queueNameForConsumer,
                RoutingKey = routingKeyForConsumer
            });
        }
        public void ListenQueue(Action sendMessage)
        {
            _messageConsumerScope.MessageConsumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body.ToArray());
                var routingKey = ea.RoutingKey;
                Console.WriteLine($" [x] Received {message} at {DateTime.Now}");
                _messageConsumerScope.MessageConsumer.SetAcknowledge(ea.DeliveryTag, true);
                Thread.Sleep(2500);
                sendMessage.Invoke();
               
            };
        }
        public void SendMessageToQueue(string message)
        {
            _messageProducerScope.MessageProducer.Send(message);
            Console.WriteLine($" [x] Send {message} at {DateTime.Now}");
            
        }
    }
}
