using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public static class RabbitMQService
    {
        public static ConnectionFactory factory;
        public static IModel channel;
        public static void CreatConnection()
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

            channel.QueueDeclare(queueName, false, false, false, null);
            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, false, false, null);
            channel.QueueBind(queueName, exchangeName, routeKey);


        }

        public static void creat(IModel channel, string message)
        {
            var sendBytes = Encoding.UTF8.GetBytes(message);
            //發布訊息到RabbitMQ Server
            channel.BasicPublish("exchange", "0000", null, sendBytes);
        }
    }
}
