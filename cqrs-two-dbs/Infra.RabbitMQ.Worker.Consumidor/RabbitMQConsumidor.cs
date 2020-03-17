using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.RabbitMQ.Worker.Consumidor
{
    public class RabbitMQConsumidor<T> where T : class
    {
        private ConnectionFactory _connectionFactory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "guest",
            Password = "guest"
        };

        public string Queue { get; }

        public RabbitMQConsumidor(string queueName)
        {
            Queue = queueName;
        }

        public void Consumir()
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: Queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += Consumer_Received;

                channel.BasicConsume(
                     queue: Queue,
                     autoAck: true,
                     consumer: consumer);
            }
        }

        private void Conexao(Action<IModel> action)
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: Queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                action(channel);
            }
        }

        public void Subscribe(Action<T> action)
        {
            Conexao(channel =>
            {
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (_, args) => action(JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(args.Body)));

                channel.BasicConsume(
                     queue: Queue,
                     autoAck: true,
                     consumer: consumer);

                Console.ReadLine();
            });
        }

        private static void Consumer_Received(
            object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);

            var jsonParsed = JsonConvert.DeserializeObject<T>(message);
        }
    }
}
