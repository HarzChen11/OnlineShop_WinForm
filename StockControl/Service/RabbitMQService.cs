using Newtonsoft.Json;
using OnlineShop.Utility;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace StockControl.Service
{
    internal static class RabbitMQService
    {
        public static ConnectionFactory factory;
        public static IModel channel;
        public static void CreatConnection(FlowLayoutPanel flowLayoutPanel1, List<StockModel> models)
        {
            factory = new ConnectionFactory
            {
                UserName = "guest",
                Password = "guest",
                HostName = "localhost"
            };

            string exchangeName = "exchange";
            string queueName = "NotifyQueue";
            string routeKey = "0000";

            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            {
                //channel.QueueBind
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicQos(0, 1, false);
                //接收到消息事件 consumer.IsRunning
                consumer.Received += (ch, ea) =>
                {
                    var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                    channel.BasicAck(ea.DeliveryTag, false);
                    string decodedMessage = HttpUtility.UrlDecode(message);
                    List<StockModel> extraItems = JsonConvert.DeserializeObject<List<StockModel>>(decodedMessage);

                    Thread.Sleep(10000);
                    flowLayoutPanel1.Invoke((Action)(() =>
                    {
                        foreach(var item in extraItems)
                        {
                            ProductStock productStock = new ProductStock(item);
                            flowLayoutPanel1.Controls.Add(productStock);
                        }
                       
                    }));

                };

                channel.BasicConsume(queueName, false, consumer);
            }
        }

    }
}

