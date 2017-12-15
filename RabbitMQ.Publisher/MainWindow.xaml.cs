using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace RabbitMQ.Publisher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string queueName = "hello*";
        string exchangName = "helloExchange";
        string routerKey = "hello";
        IConnection connection = null;

        public MainWindow()
        {
            InitializeComponent();
            var factory = new ConnectionFactory
            {
                HostName = "ftp.fcleyuan.com",
                Port = 5672,
                UserName = "user",
                Password = "bahao180183",
            };
            connection = factory.CreateConnection("helloConnnectionPublisher");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangName, "fanout", true, false, null);

                    channel.QueueDeclare(queueName, true, false, false, null);

                    channel.QueueBind(queueName, exchangName, routerKey, null);

                    string msg = $"Hello World!{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                    var body = Encoding.UTF8.GetBytes(msg);

                    //var properties = channel.CreateBasicProperties();
                    //properties.DeliveryMode = 1;

                    channel.BasicPublish(exchangName, routerKey, null, body);

                    Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}发送消息：{msg}");

                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            connection.Abort();
            connection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "worldExchange", type: "direct", durable: true, autoDelete: false, arguments: null);

                channel.QueueDeclare(queue: "world", durable: true, exclusive: false, autoDelete: false, arguments: null);

                channel.QueueBind("world", "worldExchange", "world", null);

                var body = Encoding.UTF8.GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                var properties = channel.CreateBasicProperties();
                properties.DeliveryMode = 1;

                channel.BasicPublish("worldExchange", "world", properties, body);
            }
        }
    }
}
