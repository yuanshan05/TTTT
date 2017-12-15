using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static string guid = Guid.NewGuid().ToString();
        static string queueName = $"hello*";
        static string exchangName = "helloExchange";
        static string routerKey = "hello";
        // static IConnection connection = null;

        static void Main(string[] args)
        {
            Console.WriteLine($"RabbitMQ-Consumer启动……{guid}");

            var factory = new ConnectionFactory
            {
                HostName = "ftp.fcleyuan.com",
                Port = 5672,
                UserName = "user",
                Password = "bahao180183",
            };
            var connection = factory.CreateConnection("helloConnectionSubscribe");

            try
            {
                #region Channel-1

                var channel = connection.CreateModel();
                channel.ExchangeDeclare(exchange: exchangName, type: "fanout", durable: true, autoDelete: false, arguments: null);

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
                consumer.Received += (model, e) =>
                {

                    var body = e.Body;

                    string received = Encoding.UTF8.GetString(body);

                    Console.WriteLine($"consumer1收到消息：{received}");
                };

                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumerTag: channel.ChannelNumber.ToString(),
                                     noLocal: false,
                                     exclusive: false,
                                     arguments: null,
                                     consumer: consumer);

                #endregion

                #region Channel-2


                var channel2 = connection.CreateModel();

                channel2.ExchangeDeclare("worldExchange", "direct", true, false, null);

                channel2.QueueDeclare("world", true, false, false, null);

                channel2.QueueBind("world", "worldExchange", "world", null);

                var consumer2 = new EventingBasicConsumer(channel2);
                consumer2.Received += (obj, e) =>
                {
                    string msg = Encoding.UTF8.GetString(e.Body);

                    Console.WriteLine($"consumer2收到消息:{msg}");
                };

                channel2.BasicConsume("world", true, consumer2);

                #endregion

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadKey();
        }

        //static void ConsumeRabbitMQ()
        //{
        //    using (var channel = connection.CreateModel())
        //    {
        //        channel.ExchangeDeclare(exchange: exchangName, type: "fanout", durable: true, autoDelete: false, arguments: null);

        //        Console.WriteLine($"helloConnectionSubscribe-Channel{channel.IsOpen}");

        //        channel.QueueDeclare(queue: queueName,
        //                             durable: true,
        //                             exclusive: false,
        //                             autoDelete: false,
        //                             arguments: null);

        //        channel.QueueBind(queue: queueName,
        //                          exchange: exchangName,
        //                          routingKey: routerKey,
        //                          arguments: null);

        //        var consumer = new EventingBasicConsumer(channel);
        //        consumer.Received += (model, e) =>
        //        {

        //            var body = e.Body;

        //            string received = Encoding.UTF8.GetString(body);

        //            Console.WriteLine($"收到消息：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},消息内容：{received}");
        //        };
        //        //consumer.
        //        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

        //    }

        //}

        //private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        //{
        //    Console.WriteLine($"收到消息：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        //    var body = e.Body;

        //    string received = Encoding.UTF8.GetString(body);

        //    Console.WriteLine(received);
        //}


    }
}
