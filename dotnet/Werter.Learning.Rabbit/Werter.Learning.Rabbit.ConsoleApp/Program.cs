﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Werter.Learning.Rabbit.ConsoleApp.Models;

namespace Werter.Learning.Rabbit.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm a consumer");

        


            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(@"amqp://werter:werter@localhost:5672/demo_virtualhost")
            };

            using var connection = connectionFactory.CreateConnection();
            using var model = connection.CreateModel();

            // exchange: hello <=> queue: hello
            Declare(model);
            BuildConsumer(model);


            Console.ReadKey();

        }

        private static void BuildConsumer(IModel model)
        {
            model.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(model);
            consumer.Received += (sender, eventArgs) => ProcessMessage(model, eventArgs);
            model.BasicConsume("hello_queue", false, consumer);
        }

        private static void ProcessMessage(IModel model, BasicDeliverEventArgs eventArgs)
        {
            // Tenta deserializar
            var letter = DeserializerMessage(model, eventArgs);
            
            // Chamada de negocio
            ReadLetter(model, eventArgs, letter);
        }

        // Metodo de negocio
        private static void ReadLetter(IModel model, BasicDeliverEventArgs eventArgs, Letter letter)
        {
            try
            {
                Console.WriteLine(letter.ToString());
                model.BasicAck(eventArgs.DeliveryTag, false);
            }
            catch (Exception)
            {
                model.BasicNack(eventArgs.DeliveryTag, false, true);
                throw;
            }
        }

        // Metodo de decodificação de mensagem
        private static Letter DeserializerMessage(IModel model, BasicDeliverEventArgs eventArgs)
        {
            Letter letter;
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            try
            {
                letter = System.Text.Json.JsonSerializer
                    .Deserialize<Letter>(message, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return letter;
            }
            catch (Exception)
            {
                model.BasicReject(eventArgs.DeliveryTag, false);
                throw;
            }
        }

        private static void Declare(IModel model)
        {
            model.ExchangeDeclare(
                exchange: "hello_exchange",
                type: "fanout",
                durable: true,
                autoDelete: false,
                arguments: null
            );

            model.QueueDeclare(
                queue: "hello_queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                null
            );

            model.QueueBind(
                queue: "hello_queue",
                exchange: "hello_exchange",
                "",
                null
            );
        }
    }
}