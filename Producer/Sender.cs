using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string message = "Getting started with .NET Core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);

                Console.WriteLine("Message sent {0}", message);
            }

            Console.WriteLine("Press anykey");
            Console.ReadLine();
        }
    }
}


/*
 Add nuget package RabbitMQ.Client

Setup factory and set HostName
Declare Que
call BasicPublish to publish a message in RabbitMQ

Set 'Consumer' as startup project
and it will consume all the messages that 'Producer' sent.
 */