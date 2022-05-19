using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQLibrary;
using System;
using System.Text;

namespace RabbitMQLibrary
{
    public static class ServiceCollectionExtensions
    {
        static List<string> messageTypesToListenTo = new()
        {

        };
        public static void AddMessageProducing(this IServiceCollection services, string queueName)
        {
            var queueNameService = new QueueName(queueName);
            services.AddSingleton(queueNameService);
            var connection = new RabbitMqConnection();
            services.AddSingleton(connection);

            services.AddScoped<IMessagePublisher, MessagePublisher>();

            Task.Run(() => AddMessageConsuming(queueName, connection));
        }

        public static void AddMessageConsuming(string queueName, RabbitMqConnection connection)
        {
            using (var channel = connection.CreateChannel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
            }
        }
    }
}
