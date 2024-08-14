using GeekShopping.MessageBus;
using GeekShopping.PaymentAPI.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace GeekShopping.PaymentAPI.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _userName;
        private IConnection _connection;
        private const string ExchangeName = "DirectPaymentUpdateExchange";
        private const string PaymentEmailUpdateQeueName = "PaymentEmailUpdateQeueName";
        private const string PaymentOrderUpdateQeueName = "PaymentOrderUpdateQeueName";

        public RabbitMQMessageSender()
        {
            _hostName = "localhost";
            _password = "guest";
            _userName = "guest";
        }

        public void SendMessage(BaseMessage message)
        {
            if(ConnectionExists()) 
            {
                using var channel = _connection.CreateModel();
                channel.ExchangeDeclare(ExchangeName,ExchangeType.Direct,durable: false);
                channel.QueueDeclare(PaymentEmailUpdateQeueName,durable: false, false, false, null);
                channel.QueueDeclare(PaymentOrderUpdateQeueName,durable: false, false, false, null);
                channel.QueueBind(PaymentEmailUpdateQeueName, ExchangeName, "PaymentEmail");
                channel.QueueBind(PaymentOrderUpdateQeueName, ExchangeName, "PaymentOrder");
                byte[] body = GetMessageAsByteArray(message);
                channel.BasicPublish(exchange: ExchangeName, routingKey: "PaymentEmail", basicProperties: null, body: body);
                channel.BasicPublish(exchange: ExchangeName, routingKey: "PaymentOrder", basicProperties: null, body: body);
            }
        }

        private byte[] GetMessageAsByteArray(BaseMessage message)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, //serializa as classes filhas
            };
            var json = JsonSerializer.Serialize<UpdatePaymentResultMessage>((UpdatePaymentResultMessage)message, options);
            var body = Encoding.UTF8.GetBytes(json);
            return body;
        }

        private bool ConnectionExists() 
        {
            if (_connection != null) return true;
            CreateConnection();
            return _connection != null;
        }

        private void CreateConnection()
        {
            try
            {
                var factony = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password,
                };
                _connection = factony.CreateConnection();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
