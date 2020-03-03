using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;

namespace Infra.RabbitMQ.Produtor
{
    public class RabbitMQProducer
    {
        private ConnectionFactory _connectionFactory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 15672,
            UserName = "guest",
            Password = "guest"
        };
        public string Queue { get; }

        public RabbitMQProducer(string queueName)
        {
            Queue = queueName;
        }

        public async Task Publicar(string message)
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: Queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(objeto);

                channel.BasicPublish(exchange: "",
                    routingKey: "CqrsExample",
                    basicProperties: null,
                    body: body);
            }
        }
    }
}
