using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;
using Werter.Learning.Rabbit.Models;

namespace PublisherConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Letter Publisher: {Process.GetCurrentProcess().Id} ");

            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(@"amqp://werter:werter@localhost:5672/demo_virtualhost"),
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                AutomaticRecoveryEnabled = true
            };


            using var connection = connectionFactory.CreateConnection();
            using var model = connection.CreateModel();

            model.ConfirmSelect();

            model.ExchangeDeclare("hello_exchange", "fanout", true, false, null);
            model.QueueDeclare("hello_queue", true, false, false, null);
            model.QueueBind("hello_queue", "hello_exchange", "", null);

            

            var props = model.CreateBasicProperties();
            props.Headers = new Dictionary<string, object>
            {
                //{ "content-type", "text/plain" },
                { "content-type", "application/json" }
            };

            // persistent
            props.DeliveryMode = 2;


            for (var i = 0; i < 1_000_000; i++)
            {
                var message = new Letter("Werter", "RabbitMQ", "Deus seja louvado");
                var json = System.Text.Json.JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);
                
                model.BasicPublish("hello_exchange", "", props, body);
            }

            Console.WriteLine("Terminei de publicar as mensagens");
            Console.ReadKey();
        }
    }
}