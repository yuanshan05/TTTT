using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer2
{
    class Program
    {
        string type = "fanout";

        static string guid = Guid.NewGuid().ToString();
        static string queueName = $"hello*";
        static string exchangName = "helloExchange";
        static string routerKey = "hello";

        static void Main(string[] args)
        {
            Console.WriteLine($"Consumer2启动……{guid}");
            var factory = new ConnectionFactory
            {
                HostName = "ftp.fcleyuan.com",
                Port = 5672,
                UserName = "user",
                Password = "bahao180183",
            };
            var connection = factory.CreateConnection("helloSubscribe2");
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: exchangName,
                                    type: "fanout",
                                    durable: true,
                                    autoDelete: false,
                                    arguments: null);

            channel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.QueueBind(queue: queueName,
                              exchange: exchangName,
                              routingKey: routerKey,
                              arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.Reverse().ToArray();

                string strBody = Encoding.UTF8.GetString(body);

                Console.WriteLine($"RabbitMQ-Consumer2{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:反转后内容-{strBody}");

            };

            channel.BasicConsume(queueName, true, consumer);
        }
    }
}
