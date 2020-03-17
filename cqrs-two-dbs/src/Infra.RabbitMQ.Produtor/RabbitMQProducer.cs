using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Infra.RabbitMQ.Produtor
{
    public class RabbitMQProducer<TEntity> : IDisposable where TEntity : class
    {
        private ConnectionFactory _connectionFactory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "guest",
            Password = "guest"
        };

        public string Queue { get; }

        public RabbitMQProducer(string queueName)
        {
            Queue = queueName;
        }

        public async Task Publicar(TEntity entity)
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var message = JsonConvert.SerializeObject(entity);

                var body = Encoding.UTF8.GetBytes(message);

                channel.QueueDeclare(
                    queue: Queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.BasicPublish(
                    string.Empty,
                    Queue,
                    null,
                    body: body);
            }
        }

        public void Dispose()
        {
        }
    }
}
