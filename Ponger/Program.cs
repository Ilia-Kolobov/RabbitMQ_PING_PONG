using System;
using RabbitMQ.Wrapper;

namespace Ponger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ponger started!(press any key to exit)");
            Wrapper wrapper = new Wrapper("Exchange", "Ping", "ping","Exchange", "Pong", "pong");
            wrapper.ListenQueue(() =>
            {
                wrapper.SendMessageToQueue("Pong");
            });
            Console.ReadKey();
        }
    }
}
