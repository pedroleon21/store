using RabbitMQ.Client;
using Store.Commands;
using System.Text;
using System.Text.Json;

namespace Store.Handlers
{
    public class EventSender : IEventSender
    {
        private readonly ConnectionFactory _factory;
        private const string QueueName = "email";

        public EventSender(ConnectionFactory factory)
        {
            _factory = factory;
        }

        public void Send(EmailSendCommand command)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var json = JsonSerializer.Serialize(command);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: null, body: body);
            }
        }
    }
}
