using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Infra.RabbitMQ.Produtor
{
    public class RabbitMQConsumidor<T> where T : class
    {
        private ConnectionFactory _connectionFactory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 15672,
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

                channel.BasicConsume(queue: Queue,
                     autoAck: true,
                     consumer: consumer);
            }
        }

        private static void Consumer_Received(
            object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);

            var jsonParsed = JsonConvert.DeserializeObject<T>(message);
        }
    }
}
