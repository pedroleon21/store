using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Store.Data;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.Json;
using Store.Commands;

namespace Store.Handlers
{
    public class RabbitMQCatalogHandler
    {
        private ConnectionFactory factory;
        private IEmailSender emailSender;
        private const string QueueName = "catalog";
        public RabbitMQCatalogHandler(ConnectionFactory factory,IEmailSender emailSender)
        {
            this.factory = factory;
            this.emailSender = emailSender;
        }
        public void Consume()
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    Console.WriteLine("lendo fila");
                    var body = ea.Body.ToArray();
                    var stringBody = Encoding.UTF8.GetString(body);
                    var message = JsonSerializer.Deserialize<EmailSendCommand>(stringBody) ;

                    emailSender.SendEmailAsync(message.To, message.Subject, message.Body);
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    Console.WriteLine("fim da  fila");
                };
                channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
            }
        }
    }
}