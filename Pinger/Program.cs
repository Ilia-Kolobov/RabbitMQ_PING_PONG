using System;
using RabbitMQ.Wrapper;

namespace Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pinger started!(press any key to exit)");
            Wrapper wrapper = new Wrapper("Exchange", "Pong", "pong","Exchange","Ping","ping");
            wrapper.SendMessageToQueue("Ping");
            wrapper.ListenQueue(() =>
            {
                wrapper.SendMessageToQueue("Ping");
            });
            Console.ReadKey();
        }
    }
}
