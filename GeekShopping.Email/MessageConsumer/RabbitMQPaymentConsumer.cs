
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using GeekShopping.Email.Repository;
using GeekShopping.Email.Messages;

namespace GeekShopping.Email.MessageConsumer
{
    public class RabbitMQPaymentConsumer : BackgroundService
    {
        private readonly EmailRepository _repository;
        private IConnection _connection;
        private IModel _channel;
        private const string ExchangeName = "DirectPaymentUpdateExchange";
        private const string PaymentEmailUpdateQeueName = "PaymentEmailUpdateQeueName";

        public RabbitMQPaymentConsumer(EmailRepository repository)
        {
            _repository = repository;
            var factony = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };
            _connection = factony.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(PaymentEmailUpdateQeueName,false,false,false,null);
            _channel.QueueBind(PaymentEmailUpdateQeueName, ExchangeName, "PaymentEmail");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                UpdatePaymentResultMessage message = JsonSerializer.Deserialize<UpdatePaymentResultMessage>(content);
                UpdateProcessLogs(message).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(PaymentEmailUpdateQeueName, false, consumer);
            return Task.CompletedTask;
        }

        private async Task UpdateProcessLogs(UpdatePaymentResultMessage message)
        {
            try
            {
                await _repository.LogEmail(message);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
