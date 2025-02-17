using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace SharedNotificationService
{
    public class RabbitMqServiceAsync
    {
        private readonly ConnectionFactory connectionFactory;
        const string DEFAULT_EXCHANGE = "OrderAPIExchange";
        const string DEFAULT_ROUTING_KEY = "order-api-routing-key";
        const string DEFAULT_QUEUE = "order-api-queue";

        public RabbitMqServiceAsync(string providerName, Server server)
        {
            var url = "amqp://guest:guest@localhost:5672";
            if(Server.Docker == server)
            {
                url = "amqp://guest:guest@host.docker.internal:5672";
            }
            connectionFactory = new ConnectionFactory();
            connectionFactory.Uri = new Uri(url); 
            connectionFactory.ClientProvidedName = providerName;
        }
        public async Task AddMessageToQueue(string message, string exchange = DEFAULT_EXCHANGE, string routingKey = DEFAULT_ROUTING_KEY, string queueName = DEFAULT_QUEUE)
        {
            try
            {
                using var connection = await connectionFactory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();
                await channel.ExchangeDeclareAsync(exchange, ExchangeType.Direct);
                await channel.QueueDeclareAsync(queueName, false, false, false, null);
                await channel.QueueBindAsync(queueName, exchange, routingKey);
                var body = Encoding.UTF8.GetBytes(message);
                await channel.BasicPublishAsync(exchange, routingKey, body);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error while adding message to queue: {ex.Message}");
                throw;
            }
        }
        public async Task ReadMessage(string exchange = DEFAULT_EXCHANGE, string routingKey = DEFAULT_ROUTING_KEY, string queueName = DEFAULT_QUEUE)
        {

            using var connection = await connectionFactory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(exchange, ExchangeType.Direct);
            await channel.QueueDeclareAsync(queueName, false, false, false, null);
            await channel.QueueBindAsync(queueName, exchange, routingKey);
            await channel.BasicQosAsync(0, 1, false);
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (sender, args) =>
            {
                try
                {
                    var body = args.Body.ToArray();
                    string message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Received message: {message}");
                    await channel.BasicAckAsync(args.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error while adding message to queue: {ex.Message}");
                    await channel.BasicNackAsync(args.DeliveryTag, false, true);
                    throw;
                }
            };
            await channel.BasicConsumeAsync(queueName, false, consumer);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    public enum Server
    {
        Docker,
        Local
    }
}


